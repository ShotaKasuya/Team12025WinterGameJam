using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame
{
    public class HandCardPositionsView : MonoBehaviour, ICardPositionsView
    {
        [SerializeField] private float fixPositionTime;
        [SerializeField] private List<Transform> cardPositions;

        public void StoreNewCard(ProductCardView productCardView)
        {
            CardViews.Add(productCardView);
        }

        public ProductCardView PopCardView(Card playerCard)
        {
            var cardView = CardViews.FirstOrDefault(x => x.Card.Card == playerCard);
            CardViews.Remove(cardView);
            return cardView;
        }

        public async UniTask FixPosition()
        {
            var lastTask = Task.CompletedTask;
            for (int i = 0; i < CardViews.Count; i++)
            {
                lastTask = CardViews[i].ModelTransform
                    .DOMove(cardPositions[i].position, fixPositionTime)
                    .AsyncWaitForCompletion();
            }

            await lastTask;
        }

        public IReadOnlyList<Pose> CardPositions { get; private set; }
        private List<ProductCardView> CardViews { get; } = new();
        public IReadOnlyList<ProductCardView> CardViewList => CardViews;

        private void Awake()
        {
            CardPositions = cardPositions.Select(x => new Pose(x.position, x.rotation)).ToList();
        }
    }
}