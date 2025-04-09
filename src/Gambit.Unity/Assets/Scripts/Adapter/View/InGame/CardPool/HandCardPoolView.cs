using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame.CardPool
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

        public IReadOnlyList<ProductCardView> GetViewList(PlayerId index)
        {
            return handCardPositionsViews[index.Id].CardViewList;
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