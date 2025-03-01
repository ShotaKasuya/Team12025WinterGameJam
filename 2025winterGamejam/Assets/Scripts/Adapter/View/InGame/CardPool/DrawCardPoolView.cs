using System.Collections.Generic;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.CardPool
{
    public class DrawCardPoolView: IDrawCardPoolView
    {
        public UniTask StoreNewCard(PlayerId playerId, NewProductCardView cardView)
        {
            return UniTask.CompletedTask;
        }

        public IReadOnlyList<NewProductCardView> PopAllCardViews()
        {
            return null;
        }
    }
}