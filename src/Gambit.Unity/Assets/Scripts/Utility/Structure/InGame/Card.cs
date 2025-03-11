using System;
using System.Runtime.CompilerServices;
using Gambit.Shared.DataTransferObject;
using UnityEngine;

namespace Gambit.Unity.Structure.Utility.InGame
{
    /// <summary>
    /// トランプのカード
    /// </summary>
    [Serializable]
    public struct Card : IEquatable<Card>
    {
        [SerializeField] private Suit suit;
        [SerializeField] private Rank rank;
        public Suit Suit => suit;
        public Rank Rank => rank;
        private int _buffDebuff;

        public void SetBuff(int x)
        {
            _buffDebuff = x;
        }

        public void SetDebuff(int x)
        {
            _buffDebuff = -x;
        }

        public Rank BuffRank()
        {
            if ((int)Rank < -_buffDebuff)
            {
                return 0;
            }
            else
            {
                return (Rank)((int)Rank + _buffDebuff);
            }
        }

        public bool IsGreater(Card other)
        {
            return BuffRank() > other.BuffRank();
        }

        public Card
        (
            Suit suit,
            Rank rank
        )
        {
            this.suit = suit;
            this.rank = rank;
            _buffDebuff = 0;
        }

        public bool IsEqual(Card other)
        {
            return Suit == other.Suit & Rank == other.Rank;
        }

        public override string ToString()
        {
            return $"(suit, rank) => ({Suit}, {Rank})";
        }

        public static Card[] AllCards()
        {
            var suitNum = Enum.GetValues(typeof(Suit)).Length;
            var rankNum = Enum.GetValues(typeof(Rank)).Length;
            var totalNum = suitNum * rankNum;

            var cards = new Card[totalNum];
            for (int i = 0; i < suitNum; i++)
            {
                var suit = (Suit)i;
                for (int j = 0; j < rankNum; j++)
                {
                    var rank = (Rank)j;
                    cards[i * rankNum + j] = new Card(suit, rank);
                }
            }

            return cards;
        }

        public bool Equals(Card other)
        {
            return Suit == other.Suit && Rank == other.Rank;
        }

        public override bool Equals(object obj)
        {
            return obj is Card other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)Suit, (int)Rank);
        }

        public static bool operator ==(Card left, Card right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }

        public static Card ConversationCard(RankTransferObject rank, SuitTransferObject suit)
        {
            return new Card(suit.Convert(), rank.Convert());
        }
    }

    public enum Suit
    {
        Spades, // ♠
        Hearts, // ♥
        Diamonds, // ♦
        Clubs, // ♣
    }

    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
    }

    public static partial class Converter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CardTransferObject Convert(this Card card)
        {
            return new CardTransferObject(card.Suit.Convert(), card.Rank.Convert());
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rank Convert(this RankTransferObject rankTransferObject)
        {
            return rankTransferObject switch
            {
                RankTransferObject.Two => Rank.Two,
                RankTransferObject.Three => Rank.Three,
                RankTransferObject.Four => Rank.Four,
                RankTransferObject.Five => Rank.Five,
                RankTransferObject.Six => Rank.Six,
                RankTransferObject.Seven => Rank.Seven,
                RankTransferObject.Eight => Rank.Eight,
                RankTransferObject.Nine => Rank.Nine,
                RankTransferObject.Ten => Rank.Ten,
                RankTransferObject.Jack => Rank.Jack,
                RankTransferObject.Queen => Rank.Queen,
                RankTransferObject.King => Rank.King,
                RankTransferObject.Ace => Rank.Ace,
                _ => throw new ArgumentOutOfRangeException(nameof(rankTransferObject), rankTransferObject, null)
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RankTransferObject Convert(this Rank rank)
        {
            return rank switch
            {
                Rank.Two => RankTransferObject.Two,
                Rank.Three => RankTransferObject.Three,
                Rank.Four => RankTransferObject.Four,
                Rank.Five => RankTransferObject.Five,
                Rank.Six => RankTransferObject.Six,
                Rank.Seven => RankTransferObject.Seven,
                Rank.Eight => RankTransferObject.Eight,
                Rank.Nine => RankTransferObject.Nine,
                Rank.Ten => RankTransferObject.Ten,
                Rank.Jack => RankTransferObject.Jack,
                Rank.Queen => RankTransferObject.Queen,
                Rank.King => RankTransferObject.King,
                Rank.Ace => RankTransferObject.Ace,
                _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, null)
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Suit Convert(this SuitTransferObject suitTransferObject)
        {
            return suitTransferObject switch
            {
                SuitTransferObject.Spades => Suit.Spades,
                SuitTransferObject.Hearts => Suit.Hearts,
                SuitTransferObject.Diamonds => Suit.Diamonds,
                SuitTransferObject.Clubs => Suit.Clubs,
                _ => throw new ArgumentOutOfRangeException(nameof(suitTransferObject), suitTransferObject, null)
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuitTransferObject Convert(this Suit suit)
        {
            return suit switch
            {
                Suit.Spades => SuitTransferObject.Spades,
                Suit.Hearts => SuitTransferObject.Hearts,
                Suit.Diamonds => SuitTransferObject.Diamonds,
                Suit.Clubs => SuitTransferObject.Clubs,
                _ => throw new ArgumentOutOfRangeException(nameof(suit), suit, null)
            };
        }
    }
}