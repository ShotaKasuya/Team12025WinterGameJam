using Gambit.Server.Services.Structure;

namespace Gambit.Server.Services;

public class GroupManagement
{
    private const uint PLAYER_MAX = 2;

    /// <summary>
    /// ランダムにプレイヤーを追加
    /// </summary>
    /// <returns></returns>
    public GroupId AddPlayer()
    {
        GroupId groupId;
        var group = Groups.Values.FirstOrDefault(x => x.PlayerCount <= PLAYER_MAX);
        if (group is not null)
        {
            groupId = group.AddPlayer();
        }
        else
        {
            var value = BitConverter.ToUInt32(Guid.NewGuid().ToByteArray(), 0);
            groupId = new GroupId(value);
            var newGroup = new Group(groupId);
            Groups.Add(groupId, newGroup);
        }

        return groupId;
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

    public Option<int> GroupPlayerCount(GroupId id)
    {
        return Groups.TryGetValue(id, out var group)
            ? Option<int>.Some(group.PlayerCount)
            : Option<int>.None();
    }

    private Dictionary<GroupId, Group> Groups { get; } = new();

    static GroupManagement()
    {
        Instance = new GroupManagement();
    }

    public static GroupManagement Instance { get; }
}