namespace Gambit.Server.Services.Structure;

public class Group(GroupId groupId)
{
    public readonly GroupId GroupId = groupId;

    public int PlayerCount { get; private set; }
    private List<PlayerId> Players { get; } = [];
    public IReadOnlyCollection<PlayerId> GroupPlayers => Players;

    public void AddPlayer(PlayerId playerId)
    {
        Players.Add(playerId);
        PlayerCount++;
    }

    public void RemovePlayer(PlayerId playerId)
    {
        Players.Remove(playerId);
        PlayerCount++;
    }
}

public readonly struct GroupId(uint groupId) : IEquatable<GroupId>
{
    public readonly uint Id = groupId;

    public bool Equals(GroupId other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return obj is GroupId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (int)Id;
    }
}