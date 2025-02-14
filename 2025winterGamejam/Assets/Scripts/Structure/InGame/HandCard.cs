using System.Collections.Generic;

namespace Structure.InGame
{
    public struct HandCard
    {
        public List<Card> Cards{ get; }
        public HandCard(List<Card> cards)
        {
            Cards = cards;
        }
    }
}