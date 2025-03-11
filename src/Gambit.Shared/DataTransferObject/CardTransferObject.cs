namespace Gambit.Shared.DataTransferObject
{
    public readonly struct CardTransferObject
    {
        public CardTransferObject
        (
            SuitTransferObject suit,
            RankTransferObject rank
        )
        {
            Suit = suit;
            Rank = rank;
        }
            
        public readonly SuitTransferObject Suit;
        public readonly RankTransferObject Rank;
    }
    
    public enum SuitTransferObject
    {
        Spades, // ♠
        Hearts, // ♥
        Diamonds, // ♦
        Clubs, // ♣
    }

    public enum RankTransferObject
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