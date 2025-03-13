using Gambit.Server.Services.Structure;

namespace Gambit.Server.Services;

public class GroupManagement
{
    public const uint PlayerMax = 1;

    /// <summary>
    /// ランダムにプレイヤーを追加
    /// </summary>
    /// <returns></returns>
    public (GroupId, PlayerId, int) AddPlayer()
    {
        GroupId groupId;
        var random = Guid.NewGuid().ToByteArray();
        var playerId = new PlayerId(BitConverter.ToInt32(random, 0));
        var playerIndex = 0;

        var group = Groups.Values.FirstOrDefault(x => x.GroupPlayers.Count < PlayerMax);
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
        var result = GroupReader.Values.FirstOrDefault(x => x.Has(playerId));

        if (result is null)
        {
            Console.Out.WriteLineAsync("player not found");
            var groups = GroupReader.Values.ToArray();
            for (int i = 0; i < groups.Count(); i++)
            {
                Console.Out.WriteLineAsync($"group {i} player");

                var players = groups[i].GroupPlayers;
                foreach (var player in players)
                {
                    Console.Out.WriteLineAsync($"player id: {player.Id}");
                }
            }
        }

        return result!;
    }

    public IReadOnlyDictionary<GroupId, Group> GroupReader => Groups;
    private Dictionary<GroupId, Group> Groups { get; } = new();

    static GroupManagement()
    {
        Instance = new GroupManagement();
    }

    public static GroupManagement Instance { get; }
}