using CodiceApp.Gravatar;
using Utility.Structure.InGame;

namespace Adapter.IView.InGame.Ui
{
    public interface IGameResultView
    {
        public void Enable(Result result);
        public void DisEnable();
        
    }
}