using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.CardPool
{
    public class HandCardPoolView: MonoBehaviour, IHandCardPoolView
    {
        [SerializeField] private HandCardPositionsView[] handCardPositionsViews;
        
        public UniTask StoreNewCard(NewProductCardView transformableView)
        {
            return UniTask.CompletedTask;
        }

        public NewProductCardView PopCardView(PlayerCard playerCard)
        {
            return null;
        }
    }
}