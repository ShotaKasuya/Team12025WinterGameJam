using System.Collections.Generic;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.CardPool
{
    public class WinCardPoolView: IWinCardPoolView
    {
        public UniTask StoreNewCard(PlayerId playerId, NewProductCardView transformableView)
        {
            return UniTask.CompletedTask;
        }

        public IReadOnlyList<NewProductCardView> PopAllCardViews(PlayerId playerId)
        {
            return null;
        }
    }
}