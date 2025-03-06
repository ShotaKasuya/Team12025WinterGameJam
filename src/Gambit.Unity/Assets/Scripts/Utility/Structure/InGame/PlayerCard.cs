using System;
using Gambit.Shared.DataTransferObject;
using UnityEngine;

namespace Gambit.Unity.Structure.Utility.InGame
{
    [Serializable]
    public struct PlayerCard
    {
        public PlayerCard(PlayerId playerId, Card card)
        {
            this.playerId = playerId;
            this.card = card;
        }

        [SerializeField] private PlayerId playerId;
        [SerializeField] private Card card;
        public PlayerId PlayerId => playerId;
        public Card Card => card;
        public Rank Rank => Card.Rank;
        public Suit Suit => Card.Suit;

        public bool IsGreater(PlayerCard other)
        {
            return Card.IsGreater(other.Card);
        }

        public override string ToString()
        {
            return $"(\n" +
                   $"{playerId}\n" +
                   $"Card: {card}\n" +
                   $")";
        }

        public PlayerCard ConversionSentPlayerCard(SentPlayerCard sentPlayerCard)
        {
            card=Card.ConversationCard((int)sentPlayerCard.Card.Rank, (int)sentPlayerCard.Card.Suit);
            playerId = PlayerId.ConversationId(sentPlayerCard.PlayerId.Id);
            return this;
        }
    }
}