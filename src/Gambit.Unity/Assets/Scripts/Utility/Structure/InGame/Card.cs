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

        public static Card ConversationCard(RankTransObj rank, SuitTransObj suit)
        {
            return new Card(suit.Conversion(), rank.Conversion());
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

    public static class CardExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rank Conversion(this RankTransObj rankTransObj)
        {
            return rankTransObj switch
            {
                RankTransObj.Two => Rank.Two,
                RankTransObj.Three => Rank.Three,
                RankTransObj.Four => Rank.Four,
                RankTransObj.Five => Rank.Five,
                RankTransObj.Six => Rank.Six,
                RankTransObj.Seven => Rank.Seven,
                RankTransObj.Eight => Rank.Eight,
                RankTransObj.Nine => Rank.Nine,
                RankTransObj.Ten => Rank.Ten,
                RankTransObj.Jack => Rank.Jack,
                RankTransObj.Queen => Rank.Queen,
                RankTransObj.King => Rank.King,
                RankTransObj.Ace => Rank.Ace,
                _ => throw new ArgumentOutOfRangeException(nameof(rankTransObj), rankTransObj, null)
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RankTransObj Conversion(this Rank rank)
        {
            return rank switch
            {
                Rank.Two => RankTransObj.Two,
                Rank.Three => RankTransObj.Three,
                Rank.Four => RankTransObj.Four,
                Rank.Five => RankTransObj.Five,
                Rank.Six => RankTransObj.Six,
                Rank.Seven => RankTransObj.Seven,
                Rank.Eight => RankTransObj.Eight,
                Rank.Nine => RankTransObj.Nine,
                Rank.Ten => RankTransObj.Ten,
                Rank.Jack => RankTransObj.Jack,
                Rank.Queen => RankTransObj.Queen,
                Rank.King => RankTransObj.King,
                Rank.Ace => RankTransObj.Ace,
                _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, null)
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Suit Conversion(this SuitTransObj suitTransObj)
        {
            return suitTransObj switch
            {
                SuitTransObj.Spades => Suit.Spades,
                SuitTransObj.Hearts => Suit.Hearts,
                SuitTransObj.Diamonds => Suit.Diamonds,
                SuitTransObj.Clubs => Suit.Clubs,
                _ => throw new ArgumentOutOfRangeException(nameof(suitTransObj), suitTransObj, null)
            };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SuitTransObj Conversion(this Suit suit)
        {
            return suit switch
            {
                Suit.Spades => SuitTransObj.Spades,
                Suit.Hearts => SuitTransObj.Hearts,
                Suit.Diamonds => SuitTransObj.Diamonds,
                Suit.Clubs => SuitTransObj.Clubs,
                _ => throw new ArgumentOutOfRangeException(nameof(suit), suit, null)
            };
        }
    }
}