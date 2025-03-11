using Gambit.Server.Services.Structure;

namespace Gambit.Server.Services;

public class GroupManagement
{
    private const uint PLAYER_MAX = 2;

    /// <summary>
    /// ランダムにプレイヤーを追加
    /// </summary>
    /// <returns></returns>
    public (GroupId, PlayerId) AddPlayer()
    {
        GroupId groupId;
        var random = Guid.NewGuid().ToByteArray();
        var playerId = new PlayerId(BitConverter.ToUInt32(random, 0));

        var group = Groups.Values.FirstOrDefault(x => x.PlayerCount <= PLAYER_MAX);
        if (group is not null)
        {
            groupId = group.AddPlayer(playerId);
        }
        else
        {
            var newGroupId = BitConverter.ToUInt32(random, 1);
            groupId = new GroupId(newGroupId);
            var newGroup = new Group(groupId, playerId);
            Groups.Add(groupId, newGroup);
        }

        return (groupId, playerId);
    }

    public void LeavePlayer(PlayerId playerId)
    {
        var group = Groups.Values.FirstOrDefault(x => x.Has(playerId));
        if (group is null)
        {
            throw new Exception("Group not has the player");
        }

        group.RemovePlayer(playerId);
        if (group.PlayerCount == 0)
        {
            Groups.Remove(group.Id);
        }
    }

    public Group GetGroup(PlayerId playerId)
    {
        return GroupReader.Values.First(x => x.Has(playerId));
    }

    public Option<int> GroupPlayerCount(GroupId id)
    {
        return Groups.TryGetValue(id, out var group)
            ? Option<int>.Some(group.PlayerCount)
            : Option<int>.None();
    }

    public IReadOnlyDictionary<GroupId, Group> GroupReader => Groups;
    private Dictionary<GroupId, Group> Groups { get; } = new();

    static GroupManagement()
    {
        Instance = new GroupManagement();
    }

    public static GroupManagement Instance { get; }
}