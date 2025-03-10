using CodiceApp.Gravatar;

namespace Adapter.IView.InGame.Ui
{
    public interface IGameResultView
    {
        public void Enable(Result result);
        public void DisEnable(Result result);

        public enum Result
        {
            Win,Lose,Draw
        }
    }
}