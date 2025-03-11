using Gambit.Server.Services.Structure;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using MagicOnion.Server.Hubs;

namespace Gambit.Server.Services;

public class GameMainService : StreamingHubBase<IGameMainCommunication, IGameMainReceiver>, IGameMainCommunication
{
    public async ValueTask<PlayerInitInfoTransferObject> JoinAsync()
    {
        var (groupId, playerId, index) = GroupManagement.Instance.AddPlayer();
        var group = await Group.AddAsync(groupId.ToString());
        var newGroup = GroupManagement.Instance.GroupReader[groupId];
        newGroup.SetGroup(group);

        await Console.Out.WriteLineAsync($"new player: {playerId}, groupId: {groupId}");
        var playerIdTransfer = playerId.Convert();
        return new PlayerInitInfoTransferObject(playerIdTransfer, index, newGroup.GroupSeed);
    }

    public async ValueTask LeaveAsync(PlayerIdTransferObject playerIdTransferObject)
    {
        var playerId = playerIdTransferObject.Convert();
        var group = GroupManagement.Instance.LeavePlayer(playerId);
        await group.PairGroup!.RemoveAsync(Context);
    }

    public ValueTask SendSelectedCardAsync(PlayerCardTransferObject playerCardTransferObject)
    {
        var playerId = playerCardTransferObject.PlayerId.Convert();
        var group = GroupManagement.Instance.GetGroup(playerId);
        
        group.PairGroup!.All.SendSelectedCard(playerCardTransferObject);
        return CompletedTask;
    }
}