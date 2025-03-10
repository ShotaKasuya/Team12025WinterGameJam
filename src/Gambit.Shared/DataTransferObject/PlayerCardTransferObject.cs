namespace Gambit.Shared.DataTransferObject
{
    public readonly struct PlayerCardTransferObject
    {
        public PlayerCardTransferObject(PlayerIdTransferObject playerIdTransferObject,
            CardTransferObject cardTransferObject)
        {
            PlayerId = playerIdTransferObject;
            Card = cardTransferObject;
        }

        public readonly PlayerIdTransferObject PlayerId;
        public readonly CardTransferObject Card;
    }
}