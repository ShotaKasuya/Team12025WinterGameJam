using System.Collections.Generic;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Adapter.View.InGame.CardPool
{
    public class DrawCardPoolView : MonoBehaviour, IDrawCardPoolView
    {
        [SerializeField] private Transform drawCardsPosition;
        [SerializeField] private float moveDuration;
        
        private Vector3 DrawCardsPosition => drawCardsPosition.position;
        private float MoveDuration => moveDuration;
        private List<ProductCardView> drawCards  = new List<ProductCardView>();
        private List<ProductCardView> swapDrawCards  = new List<ProductCardView>();

        public async UniTask StoreNewCard(ProductCardView cardView)
        {
            drawCards.Add(cardView);
            await cardView.ModelTransform.DOMove(DrawCardsPosition, MoveDuration).AsyncWaitForCompletion();
        }

        public IReadOnlyList<ProductCardView> PopAllCardViews()
        {
            var tmp = drawCards;
            swapDrawCards.Clear();
            drawCards = swapDrawCards;
            swapDrawCards = tmp;
            return swapDrawCards;
        }
    }
}