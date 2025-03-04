using Adapter.IModel.InGame.Player;
using Adapter.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.Linker.InGame
{
    public class CardFactory: ICardFactory
    {
        public CardFactory
        (
            ProductCardView cardView,
            IPlayerIdModel playerIdModel
        )
        {
            CardView = cardView;
            PlayerIdModel = playerIdModel;
        }
        
        public ProductCardView CreateCardView(PlayerCard playerCard)
        {
            var product = Object.Instantiate(CardView);
            product.Inject(playerCard);
            
            if (PlayerIdModel.PlayerId == playerCard.PlayerId)
            {
                product.ShowFace();
            }
            else
            {
                product.HideFace();
            }
            
            return product;
        }
        
        private ProductCardView CardView { get; }
        private IPlayerIdModel PlayerIdModel { get; }
    }
}