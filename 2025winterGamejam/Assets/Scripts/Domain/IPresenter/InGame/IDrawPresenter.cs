using Cysharp.Threading.Tasks;
using Utility.Structure.InGame;

namespace Domain.IPresenter.InGame
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