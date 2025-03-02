using System.Collections.Generic;
using System.Linq;
using Adapter.IView.InGame;
using Adapter.View.Utility;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.CardPool
{
    public class SelectedCardPoolView : MonoBehaviour, ISelectedCardPoolView
    {
        [SerializeField] private float tweenTime;
        [SerializeField] private TransformableView[] transformableViews;

        private NewProductCardView[] _cardViews;

        public async UniTask StoreNewCard(NewProductCardView cardView)
        {
            var playerId = cardView.Card.PlayerId;
            var storeTo = transformableViews[playerId.Id];

            await cardView.ModelTransform
                .DOMove(storeTo.ModelTransform.position, tweenTime)
                .AsyncWaitForCompletion();
            _cardViews[playerId.Id] = cardView;
        }

        public IReadOnlyList<NewProductCardView> PopAllCardViews()
        {
            var cards = _cardViews.ToList();
            for (int i = 0; i < _cardViews.Length; i++)
            {
                _cardViews[i] = null;
            }

            return cards;
        }

        private void Awake()
        {
            _cardViews = new NewProductCardView[transformableViews.Length];
        }
    }
}