using Cysharp.Threading.Tasks;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.IPresenter.InGame
{
    public interface IDrawPresenter
    {
        public UniTask PresentDraw(Card[] cards);
    }
    public interface IInitHandPresenter
    {
        public UniTask PresentInitHand(HandCard[] cards);
    }
}