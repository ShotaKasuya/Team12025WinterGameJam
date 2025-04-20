using Cysharp.Threading.Tasks;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IView.UseCommunication
{
    public interface IConnectView
    {
        public UniTask<InitSetting> Connect();
    }

    public interface ISendSelectedCardView
    {
        public UniTask SendPlayerCard(PlayerCard playerCard);
    }

    public interface ILeaveRoomView
    {
        public UniTask LeaveAsync();
    }
}