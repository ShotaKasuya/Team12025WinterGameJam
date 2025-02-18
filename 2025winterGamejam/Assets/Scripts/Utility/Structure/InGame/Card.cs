
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
            if ((int)Rank < - _buffDebuff)
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
    }

    public enum Suit
    {
        Spades,     // ♠
        Hearts,     // ♥
        Diamonds,   // ♦
        Clubs,      // ♣
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
    }
}