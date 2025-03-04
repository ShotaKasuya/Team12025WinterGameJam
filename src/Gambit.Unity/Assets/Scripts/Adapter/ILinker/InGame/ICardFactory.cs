using Adapter.IView.InGame;
using Utility.Structure.InGame;

namespace Adapter.ILinker.InGame
{
    public interface ICardFactory
    {
        public ProductCardView CreateCardView(PlayerCard playerCard);
    }
}