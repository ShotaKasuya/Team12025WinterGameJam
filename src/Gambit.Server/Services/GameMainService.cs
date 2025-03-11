using Gambit.Server.Services.Structure;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using MagicOnion.Server.Hubs;

namespace Gambit.Server.Services;

public class GameMainService : StreamingHubBase<IGameMainCommunication, IGameMainReceiver>, IGameMainCommunication
{
    public async ValueTask<PlayerInitInfoTransferObject> JoinAsync()
    {
        var (groupId, playerId) = GroupManagement.Instance.AddPlayer();
        var group = await Group.AddAsync(groupId.ToString());
        var newGroup = GroupManagement.Instance.GroupReader[groupId];
        newGroup.SetGroup(group);

        var playerIdTransfer = playerId.Convert();
        return new PlayerInitInfoTransferObject(playerIdTransfer, newGroup.GroupSeed);
    }

    public ValueTask MatchResultAsync(string result)
    {
        throw new NotImplementedException();
    }

    public ValueTask SendSelectedCardAsync(PlayerCardTransferObject playerCardTransferObject)
    {
        var playerId = playerCardTransferObject.PlayerId.Convert();
        var group = GroupManagement.Instance.GetGroup(playerId);
        
        group.PairGroup!.All.SendSelectedCard(playerCardTransferObject);
        return CompletedTask;
    }
}