namespace Gambit.Shared.DataTransferObject
{
    public readonly struct RoomTransferObject
    {
        public RoomTransferObject(PlayerIdTransferObject ownerId)
        {
            OwnerId = ownerId;
        }
        
        public readonly PlayerIdTransferObject OwnerId;
    }
}