using MessagePack;

namespace Gambit.Shared.DataTransferObject
{
    [MessagePackObject]
    public readonly struct PlayerCardTransferObject
    {
        public PlayerCardTransferObject
        (
            PlayerIdTransferObject playerIdTransferObject,
            CardTransferObject cardTransferObject)
        {
            PlayerId = playerIdTransferObject;
            Card = cardTransferObject;
        }

        [Key(0)] public readonly PlayerIdTransferObject PlayerId;
        [Key(1)] public readonly CardTransferObject Card;
    }
}