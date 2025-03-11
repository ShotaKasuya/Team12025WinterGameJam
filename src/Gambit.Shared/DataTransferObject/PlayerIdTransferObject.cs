namespace Gambit.Shared.DataTransferObject
{
    public readonly struct PlayerIdTransferObject
    {
        public PlayerIdTransferObject(int id)
        {
            Id = id;
        }

        public readonly int Id;
    }
}