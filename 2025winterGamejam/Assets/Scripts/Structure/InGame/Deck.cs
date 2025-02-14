using System.Collections.Generic;

namespace Structure.InGame
{
    public struct Deck
    {
        public List<Card> Cards{ get; }
        public Deck(List<Card> cards)
        {
            Cards = cards;
        }
    }
}