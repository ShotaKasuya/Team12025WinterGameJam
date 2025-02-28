using System.Collections.Generic;
using System.Linq;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.InGame
{
    public class HandCardPositionsView : MonoBehaviour, ICardPositionsView
    {
        [SerializeField] private float fixPositionTime;
        [SerializeField] private List<Transform> cardPositions;

        public void StoreNewCard(NewProductCardView productCardView)
        {
            CardViews.Add(productCardView);
        }

        public NewProductCardView PopCardView(Card playerCard)
        {
            var cardView = CardViews.FirstOrDefault(x => x.Card.Card == playerCard);
            CardViews.Remove(cardView);
            return cardView;
        }

        public async UniTask FixPosition()
        {
            for (int i = 0; i < CardViews.Count; i++)
            {
                await CardViews[i].ModelTransform
                    .DOMove(cardPositions[i].position, fixPositionTime)
                    .AsyncWaitForCompletion();
            }
        }

        public IReadOnlyList<Pose> CardPositions { get; private set; }
        private List<NewProductCardView> CardViews { get; } = new();

        private void Awake()
        {
            CardPositions = cardPositions.Select(x => new Pose(x.position, x.rotation)).ToList();
        }
    }
}