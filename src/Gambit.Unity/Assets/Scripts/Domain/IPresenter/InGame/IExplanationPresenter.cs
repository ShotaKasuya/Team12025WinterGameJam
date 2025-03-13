using Cysharp.Threading.Tasks;

namespace Gambit.Unity.Domain.IPresenter.InGame
{
    public interface IExplanationPresenter
    {
        public UniTask OnMouseEnter();
        public UniTask OnMouseExit();
    }
}