namespace Gambit.Server.Services.Structure;

public class Player
{
}

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
}