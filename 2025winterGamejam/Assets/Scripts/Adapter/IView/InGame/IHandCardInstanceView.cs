using Utility.Structure.InGame;

namespace Adapter.IView.InGame
{
    public interface IHandCardInstanceView
    {
        public ProductCardView GetInstance(Card card);
    }
}