using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.CardPool
{
    public class HandCardPoolView : MonoBehaviour, IHandCardPoolView
    {
        [SerializeField] private HandCardPositionsView[] handCardPositionsViews;

        public async UniTask StoreNewCard(NewProductCardView cardView)
        {
            var targetPlayer = cardView.Card.PlayerId.Id;
            handCardPositionsViews[targetPlayer].StoreNewCard(cardView);

            await handCardPositionsViews[targetPlayer].FixPosition();
        }

        public NewProductCardView PopCardView(PlayerCard playerCard)
        {
            return handCardPositionsViews[playerCard.PlayerId.Id].PopCardView(playerCard.Card);
        }

        public async UniTask FixPosition()
        {
            foreach (var handCardPositionsView in handCardPositionsViews)
            {
                await handCardPositionsView.FixPosition();
            }
        }
    }
}