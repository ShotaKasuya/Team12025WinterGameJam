

// public class GameMainService : StreamingHubBase<IGameMainCommunication, IGameMainReceiver>, IGameMainCommunication
// {
//     public async ValueTask<PlayerInitInfoTransferObject> JoinAsync()
//     {
//         var (groupId, playerId, _) = GroupManagement.Instance.AddPlayer();
//         var group = await Group.AddAsync(groupId.ToString());
//         var newGroup = GroupManagement.Instance.GroupReader[groupId];
//         newGroup.SetGroup(group);
//
//         if (newGroup.GroupPlayers.Count == GroupManagement.PlayerMax)
//         {
//             group.All.OnMatch();
//         }
//
//         await Console.Out.WriteLineAsync($"new player: {playerId}, groupId: {groupId}");
//         var playerIdTransfer = playerId.Convert();
//         return new PlayerInitInfoTransferObject(playerIdTransfer, newGroup.GroupSeed);
//     }
//
//     public async ValueTask LeaveAsync(PlayerIdTransferObject playerIdTransferObject)
//     {
//         var playerId = playerIdTransferObject.Convert();
//         var group = GroupManagement.Instance.LeavePlayer(playerId);
//         await group.PairGroup!.RemoveAsync(Context);
//     }
//
//     public ValueTask SendSelectedCardAsync(PlayerCardTransferObject playerCardTransferObject)
//     {
//         var playerId = playerCardTransferObject.PlayerId.Convert();
//         var group = GroupManagement.Instance.GetGroup(playerId);
//
//         Console.Out.WriteLineAsync(
//             $"player {playerId.ToString()} select ({playerCardTransferObject.Card.Suit}, {playerCardTransferObject.Card.Rank})");
//         group.PairGroup!.All.SendSelectedCard(playerCardTransferObject);
//         return CompletedTask;
//     }
// }