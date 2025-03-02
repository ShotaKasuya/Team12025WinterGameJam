using Adapter.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.CardPrefabdb
{
    public class CardFactory : INewCardFactory
    {
        public CardFactory
        (
            ProductCardView productCardView
        )
        {
            ProductCardView = productCardView;
        }

        public ProductCardView CreateCardView(PlayerCard playerCard)
        {
            var product = Object.Instantiate(ProductCardView);
            product.Inject(playerCard);
            
            return product;
        }

        private ProductCardView ProductCardView { get; }
    }
}