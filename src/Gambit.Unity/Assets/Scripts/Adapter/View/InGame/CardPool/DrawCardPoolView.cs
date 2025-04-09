using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame.CardPool
{
    public class DrawCardPoolView : MonoBehaviour, IDrawCardPoolView
    {
        [SerializeField] private Transform drawCardsPosition;
        [SerializeField] private float moveDuration;
        
        private Vector3 DrawCardsPosition => drawCardsPosition.position;
        private float MoveDuration => moveDuration;
        private List<ProductCardView> _drawCards  = new List<ProductCardView>();
        private List<ProductCardView> _bufferCards  = new List<ProductCardView>();

        public async UniTask StoreNewCard(ProductCardView cardView)
        {
            _drawCards.Add(cardView);
            await cardView.ModelTransform.DOMove(DrawCardsPosition, MoveDuration).AsyncWaitForCompletion();
        }

        public IReadOnlyList<ProductCardView> PopAllCardViews()
        {
            var tmp = _drawCards;
            _bufferCards.Clear();
            _drawCards = _bufferCards;
            _bufferCards = tmp;
            return _bufferCards;
        }
    }
}