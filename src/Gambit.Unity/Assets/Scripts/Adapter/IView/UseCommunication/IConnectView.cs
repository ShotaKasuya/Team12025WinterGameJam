using Cysharp.Threading.Tasks;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IView.UseCommunication
{
    public interface IConnectView
    {
        public UniTask<InitSetting> Connect();
    }

    public interface ISendSelectedCardView
    {
        public void SendPlayerCard(PlayerCard playerCard);
    }
}