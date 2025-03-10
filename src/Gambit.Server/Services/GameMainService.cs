using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using MagicOnion.Server.Hubs;

namespace Gambit.Server.Services;

public class GameMainService: StreamingHubBase<IGameMainCommunication, IGameMainReceiver>, IGameMainCommunication
{
    public ValueTask JoinAsync(string userName)
    {
        throw new NotImplementedException();
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