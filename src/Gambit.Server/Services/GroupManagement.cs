using Gambit.Server.Services.Structure;

namespace Gambit.Server.Services;

public class GroupManagement
{
    private const uint PLAYER_MAX = 1;

    /// <summary>
    /// ランダムにプレイヤーを追加
    /// </summary>
    /// <returns></returns>
    public (GroupId, PlayerId, int) AddPlayer()
    {
        GroupId groupId;
        var random = Guid.NewGuid().ToByteArray();
        var playerId = new PlayerId(BitConverter.ToUInt32(random, 0));
        var playerIndex = 0;

        var group = Groups.Values.FirstOrDefault(x => x.GroupPlayers.Count < PLAYER_MAX);
        if (group is not null)
        {
            playerIndex = 1;
            groupId = group.AddPlayer(playerId);
        }
        else
        {
            var newGroupId = BitConverter.ToUInt32(random, 1);
            groupId = new GroupId(newGroupId);
            var newGroup = new Group(groupId, playerId);
            Groups.Add(groupId, newGroup);
        }

        Console.Out.WriteLineAsync();
        foreach (var value in Groups.Values)
        {
            Console.Out.WriteLineAsync(value.ToString());
        }

        return (groupId, playerId, playerIndex);
    }

    public Group LeavePlayer(PlayerId playerId)
    {
        var group = Groups.Values.FirstOrDefault(x => x.Has(playerId));
        if (group is null)
        {
            throw new Exception("Group not has the player");
        }

        group.RemovePlayer(playerId);
        if (group.GroupPlayers.Count == 0)
        {
            Groups.Remove(group.Id);
        }

        return group;
    }

    public Group GetGroup(PlayerId playerId)
    {
        return GroupReader.Values.First(x => x.Has(playerId));
    }

    public IReadOnlyDictionary<GroupId, Group> GroupReader => Groups;
    private Dictionary<GroupId, Group> Groups { get; } = new();

    static GroupManagement()
    {
        Instance = new GroupManagement();
    }

    public static GroupManagement Instance { get; }
}