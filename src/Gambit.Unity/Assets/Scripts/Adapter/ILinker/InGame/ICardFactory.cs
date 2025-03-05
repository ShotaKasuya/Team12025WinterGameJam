using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.ILinker.InGame
{
    public interface ICardFactory
    {
        public ProductCardView CreateCardView(PlayerCard playerCard);
    }
}