using System;
using System.Collections.Generic;

namespace Utility.Structure.InGame
{
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
    }
}