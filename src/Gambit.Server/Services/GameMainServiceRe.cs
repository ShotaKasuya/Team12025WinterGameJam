using Gambit.Server.Services.Interface;
using Gambit.Server.Services.Structure;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using MagicOnion.Server.Hubs;

namespace Gambit.Server.Services;

public class GameMainServiceRe(IGroupManagement groupManagement)
    : StreamingHubBase<IGameMainCommunication, IGameMainReceiver>, IGameMainCommunication
{
    private const int PLAYER_MAX = 2;
    private IGroupManagement GroupManagement { get; } = groupManagement;

    public async ValueTask<PlayerInitInfoTransferObject> JoinAsync()
    {
        var result = GroupManagement.AddPlayer();
        var group = await Group.AddAsync(result.GroupId.ToString());
        var newGroup = GroupManagement.GetGroup(result.PlayerId);
        newGroup.SetGroup(group);
        var playerCount = newGroup.GroupPlayers.Count;

        if (playerCount == PLAYER_MAX)
        {
            var playerIds = newGroup.GroupPlayers.AsEnumerable().Select(x => x.Convert());
            group.All.OnMatch(new PlayersInfoTransferObject(playerIds));
        }

        await Console.Out.WriteLineAsync($"new player: {result.PlayerId}, groupId: {result.GroupId}");
        var playerIdTransfer = result.PlayerId.Convert();
        return new PlayerInitInfoTransferObject(playerIdTransfer, playerCount, newGroup.GroupSeed);
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