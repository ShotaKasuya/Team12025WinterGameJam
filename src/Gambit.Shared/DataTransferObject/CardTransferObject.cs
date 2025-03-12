using MessagePack;

namespace Gambit.Shared.DataTransferObject
{
    [MessagePackObject]
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
            
        [Key(0)]
        public readonly SuitTransferObject Suit;
        [Key(1)]
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