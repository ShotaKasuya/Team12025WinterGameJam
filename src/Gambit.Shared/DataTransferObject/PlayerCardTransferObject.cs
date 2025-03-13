using MessagePack;

namespace Gambit.Shared.DataTransferObject
{
    [MessagePackObject]
    public readonly struct PlayerCardTransferObject
    {
        public PlayerCardTransferObject
        (
            PlayerIdTransferObject playerIdTransferObject,
            int playerIndex,
            CardTransferObject cardTransferObject)
        {
            PlayerId = playerIdTransferObject;
            PlayerIndex = playerIndex;
            Card = cardTransferObject;
        }

        [Key(0)] public readonly PlayerIdTransferObject PlayerId;
        [Key(1)] public readonly int PlayerIndex;
        [Key(2)] public readonly CardTransferObject Card;
    }
}