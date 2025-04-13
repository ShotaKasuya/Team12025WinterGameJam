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
            this.card = card;
        }

        [SerializeField] private PlayerId playerId;
        [SerializeField] private Card card;
        public PlayerId PlayerId => playerId;
        public Card Card => card;
        public Rank Rank => Card.Rank;

        public void SetDebuff(int buff)
        {
            card.SetDebuff(buff);
        }

        public bool IsGreater(PlayerCard other)
        {
            return Card.IsGreater(other.Card);
        }

        public override string ToString()
        {
            return "(\n" +
                   $"{playerId}\n" +
                   $"Card: {card}\n" +
                   ")";
        }


        public static PlayerCard[] MakeMockCards(Card[] cards)
        {
            var playerCards = new PlayerCard[cards.Length];
            for (int i = 0; i < playerCards.Length; i++)
            {
                playerCards[i] = new PlayerCard(new PlayerId(i), cards[i]);
            }

            return playerCards;
        }
    }

    public static partial class Converter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PlayerCardTransferObject Convert(this PlayerCard playerCard)
        {
            return new PlayerCardTransferObject(playerCard.PlayerId.Convert(),
                playerCard.Card.Convert());
        }
    }
}