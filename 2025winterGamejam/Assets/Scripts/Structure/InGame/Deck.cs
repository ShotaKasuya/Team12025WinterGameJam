using System;
using System.Collections.Generic;

namespace Structure.InGame
{
    public struct Deck
    {
        public List<Card> Cards { get; }

        public Deck(List<Card> cards)
        {
            Cards = cards;
        }

        public static Deck SortedDeck(List<Suit> suits)
        {
            var deck = new Deck(new List<Card>());
            foreach (var suit in suits)
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Cards.Add(new Card(suit, rank));
                }
            }

            return deck;
        }

        public static Deck RandomDeck(List<Suit> suits)
        {
            var deck = new Deck(new List<Card>());
            foreach (var suit in suits)
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Cards.Add(new Card(suit, rank));
                }
            }

            return deck;
        }
    }
}