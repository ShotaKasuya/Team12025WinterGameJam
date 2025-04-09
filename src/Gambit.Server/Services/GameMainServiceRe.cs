using System;
using System.Threading.Tasks;
using Gambit.Server.Services.Interface;
using Gambit.Server.Services.Structure;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using MagicOnion.Server.Hubs;

namespace Gambit.Server.Services;

public class GameMainServiceRe(IGroupManagement groupManagement): StreamingHubBase<IGameMainCommunication, IGameMainReceiver>, IGameMainCommunication
{
    private const int PlayerMax = 2;
    private IGroupManagement GroupManagement { get; } = groupManagement;
    
    public async ValueTask<PlayerInitInfoTransferObject> JoinAsync()
    {
        var result = GroupManagement.AddPlayer();
        var group = await Group.AddAsync(result.GroupId.ToString());
        var newGroup = GroupManagement.GetGroup(result.PlayerId);
        newGroup.SetGroup(group);

        if (newGroup.GroupPlayers.Count == PlayerMax)
        {
            group.All.OnMatch();
        }

        await Console.Out.WriteLineAsync($"new player: {result.PlayerId}, groupId: {result.GroupId}");
        var playerIdTransfer = result.PlayerId.Convert();
        return new PlayerInitInfoTransferObject(playerIdTransfer, newGroup.GroupSeed);
    }

    public async ValueTask LeaveAsync(PlayerIdTransferObject playerIdTransferObject)
    {
        var playerId = playerIdTransferObject.Convert();
        var group = GroupManagement.RemovePlayer(playerId);
        await group.PairGroup!.RemoveAsync(Context);
    }

    public ValueTask SendSelectedCardAsync(PlayerCardTransferObject playerCardTransferObject)
    {
        var playerId = playerCardTransferObject.PlayerId.Convert();
        var group = GroupManagement.GetGroup(playerId);

        Console.Out.WriteLineAsync(
            $"player {playerId.ToString()} select ({playerCardTransferObject.Card.Suit}, {playerCardTransferObject.Card.Rank})");
        group.PairGroup!.All.SendSelectedCard(playerCardTransferObject);
        return CompletedTask;
    }
}