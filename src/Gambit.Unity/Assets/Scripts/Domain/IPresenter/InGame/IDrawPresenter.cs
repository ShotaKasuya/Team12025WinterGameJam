using Cysharp.Threading.Tasks;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Domain.IPresenter.InGame
{
    public interface IDrawPresenter
    {
        public UniTask PresentDraw(PlayerCard[] cards);
    }
    public interface IInitHandPresenter
    {
        public UniTask PresentInitHand(HandCard[] cards);
    }
}