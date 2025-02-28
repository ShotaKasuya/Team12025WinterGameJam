using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;

namespace Domain.Presenter.InGame
{
    public class AddPointPresenter: IAddPointPresenter
    {
        public UniTask PresentAddPoint(int[] points)
        {
            return UniTask.CompletedTask;
        }
    }
}