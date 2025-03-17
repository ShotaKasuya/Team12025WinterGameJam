using System;
using System.Collections.Generic;

namespace Gambit.Unity.Structure.Utility.InGame
{
    [Serializable]
    public struct Deck
    {
        public PlayerId PlayerId { get; }
        public Stack<Card> Cards { get; }

        public Deck(List<Card> cards, PlayerId playerId)
        {
            Cards = new Stack<Card>(cards);
            PlayerId = playerId;
        }

        public PlayerCard Pop()
        {
            var card = Cards.Pop();
            return new PlayerCard(PlayerId, card);
        }

        public override string ToString()
        {
            return $"ownerId : {PlayerId} deck : {string.Join(",\n", Cards)}";
        }
    }
}