using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame.CardPool
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