using Adapter.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.CardPrefabdb
{
    public class CardFactory : INewCardFactory
    {
        public CardFactory
        (
            IGetPrefab getPrefab
        )
        {
            GetPrefab = getPrefab;
        }

        public ProductCardView CreateCardView(PlayerCard playerCard)
        {
            var product = Object.Instantiate(GetPrefab.GetProductCardView(playerCard.Card));
            product.Inject(playerCard);
            
            return product;
        }

        private IGetPrefab GetPrefab {get;}

    }
}