using System;
using System.Runtime.CompilerServices;
using Gambit.Shared.DataTransferObject;
using UnityEngine;

namespace Gambit.Unity.Utility.Structure.InGame
{
    [Serializable]
    public struct PlayerId: IEquatable<PlayerId>
    {
        public PlayerId(int id)
        {
            this.id = id;
        }

        [SerializeField] private int id;
        public int Id => id;

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

        public override string ToString()
        {
            return $"PlayerId: {Id}";
        }
    }
    
    public static partial class Converter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PlayerIdTransferObject Convert(this PlayerId playerId)
        {
            return new PlayerIdTransferObject(playerId.Id);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PlayerId Convert(this PlayerIdTransferObject playerId)
        {
            return new PlayerId(playerId.Id);
        }
    }
}