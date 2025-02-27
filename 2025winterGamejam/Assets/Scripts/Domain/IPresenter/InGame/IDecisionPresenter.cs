using Cysharp.Threading.Tasks;

namespace Domain.IPresenter.InGame
{
    public interface IDecisionPresenter
    {
        public UniTask PresentDecision();
    }
}