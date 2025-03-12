using System;
using System.Runtime.CompilerServices;
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

        public static PlayerCard ConversionSentPlayerCard(PlayerCardTransferObject playerCardTransferObject)
        {
            var card = Card.ConversationCard(playerCardTransferObject.Card.Rank, playerCardTransferObject.Card.Suit);
            var playerId = playerCardTransferObject.PlayerId.Convert();
            return new PlayerCard(playerId, card);
        }
    }
    
    public static partial class Converter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PlayerCardTransferObject Convert(this PlayerCard playerCard)
        {
            return new PlayerCardTransferObject(playerCard.PlayerId.Convert(), playerCard.Card.Convert());
        }
    }
}