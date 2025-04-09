using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.Controller.InGame
{
    /// <summary>
    /// デバッグ用に相手のカードも表示する
    /// </summary>
    public class DebugCardFactory: ICardFactory
    {
        public DebugCardFactory
        (
            ProductCardView cardView
        )
        {
            CardView = cardView;
        }

        public ProductCardView CreateCardView(PlayerCard playerCard)
        {
            var product = Object.Instantiate(CardView);
            product.Inject(playerCard);

            product.ShowFace();

            return product;
        }

        private ProductCardView CardView { get; }
    }
}