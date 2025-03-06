namespace Gambit.Shared.DataTransferObject
{
    public struct Card
    {
            
        private Suit suit;
        private Rank rank;
        public Suit Suit => suit;
        public Rank Rank => rank;
        
        public Card
        (
            Suit suit,
            Rank rank
        )
        {
            this.suit = suit;
            this.rank = rank;
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
}