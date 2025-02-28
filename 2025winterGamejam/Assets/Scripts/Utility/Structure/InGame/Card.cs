using System;

namespace Utility.Structure.InGame
{
    /// <summary>
    /// トランプのカード
    /// </summary>
    public struct Card
    {
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
            Suit = suit;
            Rank = rank;
            _buffDebuff = 0;
        }

        public Suit Suit { get; }
        public Rank Rank { get; }

        public bool IsEqual(Card other)
        {
            return Suit == other.Suit & Rank == other.Rank;
        }

        public override string ToString()
        {
            return $"(suit, rank) => ({Suit}, {Rank})\n";
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

    public readonly struct PlayerCard
    {
        public PlayerCard(PlayerId playerId, Card card)
        {
            PlayerId = playerId;
            Card = card;
        }
        
        public PlayerId PlayerId { get; }
        public Card Card { get; }
        public Rank Rank => Card.Rank;
        public Suit Suit => Card.Suit;

        public bool IsGreater(PlayerCard other)
        {
            return Card.IsGreater(other.Card);
        }
    }
}