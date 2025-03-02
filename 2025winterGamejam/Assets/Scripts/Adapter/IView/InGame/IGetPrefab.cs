using Utility.Structure.InGame;

namespace Adapter.IView.InGame
{
    public interface IGetPrefab
    {
        public ProductCardView GetProductCardView(Card card);
    }
}