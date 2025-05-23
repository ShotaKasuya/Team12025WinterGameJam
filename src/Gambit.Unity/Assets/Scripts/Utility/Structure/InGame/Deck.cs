using System;
using System.Collections.Generic;

namespace Gambit.Unity.Utility.Structure.InGame
{
    [Serializable]
    public struct Deck
    {
        public PlayerId PlayerId { get; }
        public Stack<Card> Cards { get; }

        public Deck(List<Card> cards, PlayerId playerId, int playerIndex)
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