using System;
using System.Collections.Generic;
using System.Linq;
using Gambit.Shared;
using MagicOnion.Server.Hubs;

namespace Gambit.Server.Services.Structure;

public class Group(GroupId id, PlayerId playerId)
{
    public readonly GroupId Id = id;
    public readonly PlayerId Owner = playerId;
    public readonly int GroupSeed = Random.Shared.Next();
    
    public IGroup<IGameMainReceiver>? PairGroup { get; private set; }
    private List<PlayerId> Players { get; } = new(2);
    public IReadOnlyCollection<PlayerId> GroupPlayers => Players;

    public GroupId AddPlayer(PlayerId newPlayerId)
    {
        Players.Add(newPlayerId);
        return Id;
    }

    public void RemovePlayer(PlayerId removePlayerId)
    {
        Players.Remove(removePlayerId);
    }

    public bool Has(PlayerId id)
    {
        return GroupPlayers.Contains(id);
    }

    public void SetGroup(IGroup<IGameMainReceiver> group)
    {
        PairGroup = group;
    }

    public override string ToString()
    {
        return $"id: {Id}, ownerId: {Owner}, groupSeed: {GroupSeed}, playerCount: {Players.Count}";
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