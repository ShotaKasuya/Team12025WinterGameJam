using Cysharp.Threading.Tasks;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.IPresenter.InGame
{
    public interface IDecisionPresenter
    {
        public UniTask PresentDecision(PlayerCard[] cards);
    }
}