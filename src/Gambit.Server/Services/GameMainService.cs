using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using MagicOnion.Server.Hubs;

namespace Gambit.Server.Services;

public class GameMainService: StreamingHubBase<IGameMainCommunication, IGameMainReceiver>, IGameMainCommunication
{
    public async ValueTask JoinAsync(string userName)
    {
        var (groupId, playerId) = GroupManagement.Instance.AddPlayer();
        var group = await Group.AddAsync(groupId.ToString());
        GroupManagement.Instance.GroupReader[groupId].SetGroup(group);
    }

    public ValueTask MatchResultAsync(string result)
    {
        throw new NotImplementedException();
    }

    public ValueTask SendSelectedCardAsync(PlayerCardTransferObject playerCardTransferObject)
    {
        throw new NotImplementedException();
    }
}