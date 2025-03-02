using System;
using System.Collections.Generic;
using Adapter.IView.InGame;
using Utility.Structure.InGame;
using Object = UnityEngine.Object;

namespace Adapter.View.InGame.Player
{
    public class CardFactory: ICardFactory
    {
        public CardFactory
        (
            ProductCardView productCardView,
            IGetPrefab iGetPrefab
        )
        {
            ProductCardView = productCardView;
            IGetPrefab = iGetPrefab;
        }
        
        public ProductCardView CreateCardView(Card card)
        {
            var instance = Object.Instantiate(IGetPrefab.GetProductCardView(card));
            instance.Inject(card,DeleteCardView );
            FactoryProducts.Add(instance);
            OnCreateView?.Invoke(instance);

            return instance;
        }

        private void DeleteCardView(ProductCardView cardView)
        {
            FactoryProducts.Remove(cardView);
        }

        public IReadOnlyList<ProductCardView> Products => FactoryProducts;
        public Action<ProductCardView> OnCreateView { get; set; }

        private List<ProductCardView> FactoryProducts { get; } = new List<ProductCardView>();
        private ProductCardView ProductCardView { get; }
        private IGetPrefab IGetPrefab {get;}
    }
}