using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IView.UseCommunication
{
    public interface IUseSendCard
    {
        public void  UseSendCard(PlayerCard playerCard);
    }

    public interface IUseSendSelectedCard
    {
        public void  UseSendSelectedCard(PlayerCard playerCard);
    }
}