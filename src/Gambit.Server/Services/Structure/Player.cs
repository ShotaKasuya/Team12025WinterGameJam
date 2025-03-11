using Gambit.Shared.DataTransferObject;

namespace Gambit.Server.Services.Structure;

public readonly struct PlayerId(uint playerId) : IEquatable<PlayerId>
{
    public readonly uint Id = playerId;

    public bool Equals(PlayerId other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return obj is PlayerId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (int)Id;
    }

    public static bool operator ==(PlayerId lhs, PlayerId rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(PlayerId lhs, PlayerId rhs)
    {
        return !(lhs == rhs);
    }

    public override string ToString()
    {
        return Id.ToString();
    }
}

public static partial class Converter
{
    public static PlayerId Convert(this PlayerIdTransferObject transferObject)
    {
        return new PlayerId((uint)transferObject.Id);
    }

    public static PlayerIdTransferObject Convert(this PlayerId playerId)
    {
        return new PlayerIdTransferObject((int)playerId.Id);
    }
}