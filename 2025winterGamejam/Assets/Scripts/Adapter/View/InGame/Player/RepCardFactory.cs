using Adapter.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.Player
{
    public class RepCardFactory: INewCardFactory
    {
        public RepCardFactory
        (
            IGetPrefab getPrefab
        )
        {
            GetPrefab = getPrefab;
        }
        
        public NewProductCardView CreateCardView(PlayerCard playerCard)
        {
            var instance = Object.Instantiate(GetPrefab.GetProductCardView(playerCard.Card));
            // instance.Inject(playerCard);
            //
            // return instance;
            return null;
        }
        
        private IGetPrefab GetPrefab { get; }
    }
}