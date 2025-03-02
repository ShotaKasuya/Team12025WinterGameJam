using Adapter.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.CardPrefabdb
{
    public class CardFactory : INewCardFactory
    {
        public CardFactory
        (
            NewProductCardView productCardView
        )
        {
            ProductCardView = productCardView;
        }

        public NewProductCardView CreateCardView(PlayerCard playerCard)
        {
            var product = Object.Instantiate(ProductCardView);
            product.Inject(playerCard);
            
            return product;
        }

        private NewProductCardView ProductCardView { get; }
    }
}