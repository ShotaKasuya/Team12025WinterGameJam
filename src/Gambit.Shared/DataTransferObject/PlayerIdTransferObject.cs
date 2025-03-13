using MessagePack;

namespace Gambit.Shared.DataTransferObject
{
    /// <summary>
    /// プレイヤーの`id`の`ValueObject`
    /// </summary>
    [MessagePackObject]
    public readonly struct PlayerIdTransferObject
    {
        public PlayerIdTransferObject(int id)
        {
            Id = id;
        }

        [Key(0)]
        public readonly int Id;
    }
}