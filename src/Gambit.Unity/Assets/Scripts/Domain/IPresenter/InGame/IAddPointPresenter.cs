using Cysharp.Threading.Tasks;

namespace Gambit.Unity.Domain.IPresenter.InGame
{
    public interface IAddPointPresenter
    {
        public UniTask PresentAddPoint(int[] points);
    }
}