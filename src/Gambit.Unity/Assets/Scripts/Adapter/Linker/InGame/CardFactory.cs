using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.Linker.InGame
{
    public class CardFactory: ICardFactory
    {
        public CardFactory
        (
            ProductCardView cardView,
            IPlayerIndexModel playerIdModel
        )
        {
            CardView = cardView;
            PlayerIdModel = playerIdModel;
        }
        
        public ProductCardView CreateCardView(PlayerCard playerCard)
        {
            var product = Object.Instantiate(CardView);
            product.Inject(playerCard);
            
            if (PlayerIdModel.PlayerIndex == playerCard.PlayerId)
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
        private IPlayerIndexModel PlayerIdModel { get; }
    }
}