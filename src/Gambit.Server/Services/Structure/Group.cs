using Gambit.Shared;
using MagicOnion.Server.Hubs;

namespace Gambit.Server.Services.Structure;

public class Group(GroupId id, PlayerId playerId)
{
    public readonly GroupId Id = id;
    public readonly PlayerId Owner = playerId;
    
    public IGroup<IGameMainReceiver>? PairGroup { get; private set; }
    public int PlayerCount { get; private set; }
    private List<PlayerId> Players { get; } = new(2);
    private IReadOnlyCollection<PlayerId> GroupPlayers => Players;

    public GroupId AddPlayer(PlayerId newPlayerId)
    {
        Players.Add(newPlayerId);
        PlayerCount++;
        return Id;
    }

    public void RemovePlayer(PlayerId removePlayerId)
    {
        Players.Remove(removePlayerId);
        PlayerCount--;
    }

    public bool Has(PlayerId id)
    {
        return GroupPlayers.Contains(id);
    }

    public void SetGroup(IGroup<IGameMainReceiver> group)
    {
        PairGroup = group;
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