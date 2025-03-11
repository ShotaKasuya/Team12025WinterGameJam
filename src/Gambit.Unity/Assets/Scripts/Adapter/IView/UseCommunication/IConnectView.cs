using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IView.UseCommunication
{
    public interface IConnectView
    {
        public void Connect();
    }

    public interface ISendSelectedCardView
    {
        public void SendPlayerCard(PlayerCard playerCard);
    }
}