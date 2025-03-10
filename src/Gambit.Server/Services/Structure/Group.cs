namespace Gambit.Server.Services.Structure;

public class Group(GroupId id)
{
    public readonly GroupId Id = id;

    public int PlayerCount { get; private set; }
    private List<PlayerId> Players { get; } = new(2);
    private IReadOnlyCollection<PlayerId> GroupPlayers => Players;

    public GroupId AddPlayer()
    {
        var id = (uint)Players.Count;
        Players.Add(new PlayerId(id));
        PlayerCount++;
        return Id;
    }

    public void RemovePlayer(PlayerId playerId)
    {
        Players.Remove(playerId);
        PlayerCount--;
    }

    public bool Has(PlayerId id)
    {
        return GroupPlayers.Contains(id);
    }
}

public readonly struct GroupId(uint groupId) : IEquatable<GroupId>
{
    private readonly uint _id = groupId;

    public bool Equals(GroupId other)
    {
        return _id == other._id;
    }

    public override bool Equals(object? obj)
    {
        return obj is GroupId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (int)_id;
    }

    public static bool operator ==(GroupId lhs, GroupId rhs)
    {
        return lhs.Equals(rhs);
    }

    public static bool operator !=(GroupId lhs, GroupId rhs)
    {
        return !(lhs == rhs);
    }

    public override string ToString()
    {
        return _id.ToString();
    }
}