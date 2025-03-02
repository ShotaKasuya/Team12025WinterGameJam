using System.Collections.Generic;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

namespace Adapter.View.InGame.CardPool
{
    public class DrawCardPoolView : MonoBehaviour, IDrawCardPoolView
    {
        public Vector3 DrawCardsPosition => drawCardsPosition.position;
        public float MoveDuration => moveDuration;
        [SerializeField] private Transform drawCardsPosition;
        [SerializeField] private float moveDuration;
        public List<NewProductCardView> DrawCards { get; private set; }
        public List<NewProductCardView> DrawCardsSwap { get; private set; }

        public async UniTask StoreNewCard(NewProductCardView cardView)
        {
            DrawCards.Add(cardView);
            await cardView.ModelTransform.DOMove(DrawCardsPosition, MoveDuration).AsyncWaitForCompletion();
        }

        public IReadOnlyList<NewProductCardView> PopAllCardViews()
        {
            var tmp = DrawCards;
            DrawCardsSwap.Clear();
            DrawCards = DrawCardsSwap;
            DrawCardsSwap = tmp;
            return DrawCardsSwap;
        }
    }
}