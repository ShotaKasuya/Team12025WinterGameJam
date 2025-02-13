namespace Structure.InGame
{
    /// <summary>
    /// トランプのカード
    /// </summary>
    public struct Card
    {
        public bool IsGreater(Card other)
        {
            return Rank > other.Rank;
        }
            
        public Card
        (
            Suit suit,
            Rank rank
        )
        {
            Suit = suit;
            Rank = rank;
        }

        public Suit Suit { get; }
        public Rank Rank { get; }
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
        Ace = 1,
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
    }
    
    public static class CardExtension
    {
    }
}