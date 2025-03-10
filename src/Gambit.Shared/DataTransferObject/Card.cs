namespace Gambit.Shared.DataTransferObject
{
    public struct Card
    {
            
        private SuitTransObj suit;
        private RankTransObj rank;
        public SuitTransObj Suit => suit;
        public RankTransObj Rank => rank;
        
        public Card
        (
            SuitTransObj suit,
            RankTransObj rank
        )
        {
            this.suit = suit;
            this.rank = rank;
        }
    }
    
    public enum SuitTransObj
    {
        Spades, // ♠
        Hearts, // ♥
        Diamonds, // ♦
        Clubs, // ♣
    }

    public enum RankTransObj
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