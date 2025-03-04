using System;
using System.Collections.Generic;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.CardPool
{
    public class HandCardPoolView : MonoBehaviour, IHandCardPoolView
    {
        [SerializeField] private HandCardPositionsView[] handCardPositionsViews;

        public async UniTask StoreNewCard(ProductCardView cardView)
        {
            var targetPlayer = cardView.Card.PlayerId.Id;
            handCardPositionsViews[targetPlayer].StoreNewCard(cardView);

            await handCardPositionsViews[targetPlayer].FixPosition();
            OnStore?.Invoke(cardView);
        }

        public IReadOnlyList<ProductCardView> GetViewList(PlayerId playerId)
        {
            return handCardPositionsViews[playerId.Id].CardViewList;
        }

        public ProductCardView PopCardView(PlayerCard playerCard)
        {
            var popCardView = handCardPositionsViews[playerCard.PlayerId.Id].PopCardView(playerCard.Card);
            OnPop?.Invoke(popCardView);
            return popCardView;
        }

        public async UniTask FixPosition()
        {
            var lastTask = UniTask.CompletedTask;
            foreach (var handCardPositionsView in handCardPositionsViews)
            {
                lastTask = handCardPositionsView.FixPosition();
            }

            await lastTask;
        }

        public Action<ProductCardView> OnStore { get; set; }
        public Action<ProductCardView> OnPop { get; set; }
    }
}