using Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IView.InGame.Ui
{
    public interface IGameResultView
    {
        public void Enable(Result result);
        public void DisEnable();
    }
}