using Gambit.Shared.DataTransferObject;

namespace Gambit.Server.Services.Structure;

public readonly struct PlayerId(int playerId) : IEquatable<PlayerId>
{
    public readonly int Id = playerId;

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
        return new PlayerId(transferObject.Id);
    }

    public static PlayerIdTransferObject Convert(this PlayerId playerId)
    {
        return new PlayerIdTransferObject(playerId.Id);
    }
}