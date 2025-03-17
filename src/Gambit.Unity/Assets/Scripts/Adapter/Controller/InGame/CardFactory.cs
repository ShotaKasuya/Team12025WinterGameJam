using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.Controller.InGame
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