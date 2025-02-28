using System;

namespace Utility.Structure.InGame
{
    public struct PlayerId: IEquatable<PlayerId>
    {
        public PlayerId(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public bool Equals(PlayerId other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(PlayerId left, PlayerId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlayerId left, PlayerId right)
        {
            return !(left == right);
        }
    }
}