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
        [SerializeField] private Transform newProductCardsViewsPosition;
        [SerializeField] private float moveDuration;

        private List<ProductCardView> winCardViews = new List<ProductCardView>();
        private List<ProductCardView> swapWinCardViews = new List<ProductCardView>();
        private Vector3 NewProductCardsViewsPosition => newProductCardsViewsPosition.position;
        private float MoveDuration => moveDuration;

        public async UniTask StoreNewCard(ProductCardView cardView)
        {
            winCardViews.Add(cardView);
            await cardView.ModelTransform.DOMove(NewProductCardsViewsPosition, MoveDuration).AsyncWaitForCompletion();
        }

        public IReadOnlyList<ProductCardView> PopAllCardViews(PlayerId playerId)
        {
            var tmp = winCardViews;
            swapWinCardViews.Clear();
            winCardViews = swapWinCardViews;
            swapWinCardViews = tmp;
            return swapWinCardViews;
        }
    }
}