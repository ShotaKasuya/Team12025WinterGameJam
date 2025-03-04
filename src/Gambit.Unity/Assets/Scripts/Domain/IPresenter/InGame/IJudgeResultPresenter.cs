using Cysharp.Threading.Tasks;
using Utility.Structure.InGame;

namespace Domain.IPresenter.InGame
{
    public interface IJudgeResultPresenter
    {
        public UniTask PresentResult(BattleResult result);
    }
}