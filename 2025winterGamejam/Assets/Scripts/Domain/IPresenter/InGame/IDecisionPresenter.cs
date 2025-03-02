using Cysharp.Threading.Tasks;
using Utility.Structure.InGame;

namespace Domain.IPresenter.InGame
{
    public interface IDecisionPresenter
    {
        public UniTask PresentDecision(PlayerCard[] cards);
    }
}