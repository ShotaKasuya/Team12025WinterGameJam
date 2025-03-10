using System;
using UnityEngine;

namespace Gambit.Unity.Structure.Utility.InGame
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

        public static PlayerId ConversationId(Shared.DataTransferObject.PlayerIdTransferObject idTransferObject)
        {
            return new PlayerId(idTransferObject.Id);
        }
    }
}