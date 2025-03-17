using System;
using System.Runtime.CompilerServices;
using Gambit.Shared.DataTransferObject;
using UnityEngine;

namespace Gambit.Unity.Utility.Structure.InGame
{
    [Serializable]
    public struct PlayerCard
    {
        public PlayerCard(PlayerId playerId, Card card)
        {
            this.playerId = playerId;
            playerIndex = 0;
            this.card = card;
        }

        public PlayerCard(PlayerId playerId, int playerIndex, Card card)
        {
            this.playerId = playerId;
            this.playerIndex = playerIndex;
            this.card = card;
        }

        [SerializeField] private PlayerId playerId;
        [SerializeField] private int playerIndex;
        [SerializeField] private Card card;
        public PlayerId PlayerId => playerId;
        public int PlayerIndex => playerIndex;
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


        public static PlayerCard ConversionSentPlayerCard(PlayerCardTransferObject playerCardTransferObject)
        {
            var card = Card.ConversationCard(playerCardTransferObject.Card.Rank, playerCardTransferObject.Card.Suit);
            var playerId = playerCardTransferObject.PlayerId.Convert();
            return new PlayerCard(playerId, playerCardTransferObject.PlayerIndex, card);
        }
    }

    public static partial class Converter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PlayerCardTransferObject Convert(this PlayerCard playerCard)
        {
            return new PlayerCardTransferObject(playerCard.PlayerId.Convert(), playerCard.PlayerIndex,
                playerCard.Card.Convert());
        }
    }
}