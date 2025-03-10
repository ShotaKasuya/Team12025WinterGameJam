using Gambit.Server.Services.Structure;

namespace Gambit.Server.Services;

public class GroupManagement
{
    public void AddPlayer(GroupId groupId, PlayerId playerId)
    {
        if (Groups.TryGetValue(groupId, out var group))
        {
            group.AddPlayer(playerId);
        }
        else
        {
            uint value = BitConverter.ToUInt32(Guid.NewGuid().ToByteArray(), 0);
            var newId = new GroupId(value);
            var newGroup = new Group(newId);
            Groups.Add(newId, newGroup);
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