using System;
using MessagePack;

namespace Gambit.Shared.DataTransferObject
{
    /// <summary>
    /// プレイヤーの`id`の`ValueObject`
    /// </summary>
    [MessagePackObject]
    public readonly struct PlayerIdTransferObject : IEquatable<PlayerIdTransferObject>
    {
        public PlayerIdTransferObject(int id)
        {
            Id = id;
        }

        [Key(0)] public readonly int Id;

        public override string ToString()
        {
            return $"player id: {Id}";
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerIdTransferObject other && Equals(other);
        }

        public bool Equals(PlayerIdTransferObject other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(PlayerIdTransferObject left, PlayerIdTransferObject right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlayerIdTransferObject left, PlayerIdTransferObject right)
        {
            return !(left == right);
        }
    }
}