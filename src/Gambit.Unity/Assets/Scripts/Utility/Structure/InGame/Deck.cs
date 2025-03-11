using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Gambit.Unity.Structure.Utility.InGame
{
    [Serializable]
    public struct Deck
    {
        public Stack<Card> Cards { get; }

        public Deck(List<Card> cards)
        {
            Cards = new Stack<Card>(cards);
        }

        public static Deck SortedDeck(List<Suit> suits)
        {
            var cards = new List<Card>();
            foreach (var suit in suits)
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }

            var deck = new Deck(cards);

            return deck;
        }

        public static Deck[] RandomDecks(int deckNum, int seed)
        {
            var suitNum = Enum.GetValues(typeof(Suit)).Length;
            var rankNum = Enum.GetValues(typeof(Rank)).Length;

            var decks = new Card[deckNum, suitNum * rankNum / deckNum];
            var cards = Card.AllCards().ToList();
            Random.InitState(seed);
            for (int i = 0; i < deckNum; i++)
            {
                for (int j = 0; j < suitNum * rankNum / deckNum; j++)
                {
                    var index = Random.Range(0, cards.Count);
                    decks[i, j] = cards[index];
                    cards.RemoveAt(index);
                }
            }

            var result = new Deck[deckNum];
            for (int i = 0; i < deckNum; i++)
            {
                var deck = GetRow(i);
                result[i] = new Deck(deck);
            }

            return result;

            List<Card> GetRow(int rowIndex)
            {
                var cols = decks.GetLength(1);
                var row = new List<Card>(cols);
                for (int i = 0; i < cols; i++)
                {
                    var card = decks[rowIndex, i];
                    row.Add(card);
                }

                return row;
            }
        }
    }
}