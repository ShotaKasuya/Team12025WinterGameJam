using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.CardPool
{
    public class HandCardPoolView: IHandCardPoolView
    {
        public UniTask StoreNewCard(PlayerId playerId, NewProductCardView transformableView)
        {
            return UniTask.CompletedTask;
        }

        public NewProductCardView PopCardView(PlayerCard playerCard)
        {
            return null;
        }
    }
}