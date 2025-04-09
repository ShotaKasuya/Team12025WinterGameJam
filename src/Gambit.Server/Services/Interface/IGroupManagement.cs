using Gambit.Server.Services.Structure;

namespace Gambit.Server.Services.Interface;

public interface IGroupManagement
{
    public AddPlayerResult AddPlayer();
    public Group RemovePlayer(PlayerId playerId);
    public GroupId GetGroupId(PlayerId playerId);
    public Group GetGroup(PlayerId playerId);
}

public readonly struct AddPlayerResult(GroupId groupId, PlayerId playerId)
{
    public GroupId GroupId { get; } = groupId;
    public PlayerId PlayerId { get; } = playerId;
}