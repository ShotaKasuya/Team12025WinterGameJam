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
        [SerializeField] private List<Transform> cardPositions;

        public async UniTask StoreNewCard(NewProductCardView productCardView)
        {
            _cardViews.Add(productCardView);
            await FixPosition();
        }

        public async UniTask<NewProductCardView> PopCardView(Card playerCard)
        {
            var cardView = _cardViews.FirstOrDefault(x => x.Card.Card == playerCard);
            _cardViews.Remove(cardView);
            await FixPosition();
            return cardView;
        }

        private async UniTask FixPosition()
        {
            for (int i = 0; i < _cardViews.Count; i++)
            {
                // FIXME : duration
                await _cardViews[i].ModelTransform
                    .DOMove(cardPositions[i].position, 1)
                    .AsyncWaitForCompletion();
            }
        }
            
        public IReadOnlyList<Pose> CardPositions { get; private set; }
        private List<NewProductCardView> _cardViews = new ();

        private void Awake()
        {
            CardPositions = cardPositions.Select(x => new Pose(x.position, x.rotation)).ToList();
        }
    }
}