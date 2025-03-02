using System.Collections.Generic;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.CardPool
{
    public class WinCardPoolView : MonoBehaviour, IWinCardPoolView
    {
        public List<NewProductCardView> NewProductCardViews { get; private set; }
        public List<NewProductCardView> NewProductCardViewsSwap { get; private set; }
        public Vector3 NewProductCardsViewsPosition => newProductCardsViewsPosition.position;
        public float MoveDuration => moveDuration;
        [SerializeField] private Transform newProductCardsViewsPosition;
        [SerializeField] private float moveDuration;

        public async UniTask StoreNewCard(NewProductCardView cardView)
        {
            NewProductCardViews.Add(cardView);
            await cardView.ModelTransform.DOMove(NewProductCardsViewsPosition, MoveDuration).AsyncWaitForCompletion();
        }

        public IReadOnlyList<NewProductCardView> PopAllCardViews(PlayerId playerId)
        {
            var tmp = NewProductCardViews;
            NewProductCardViewsSwap.Clear();
            NewProductCardViews = NewProductCardViewsSwap;
            NewProductCardViewsSwap = tmp;
            return NewProductCardViewsSwap;
        }
    }
}