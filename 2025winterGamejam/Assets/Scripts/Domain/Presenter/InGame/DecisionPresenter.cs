using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;

namespace Domain.Presenter.InGame
{
    public class DecisionPresenter: IDecisionPresenter
    {
        public UniTask PresentDecision()
        {
            return UniTask.CompletedTask;
        }
    }
}