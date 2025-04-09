using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Adapter.View.Utility;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame.CardPool
{
    public class SelectedCardPoolView : MonoBehaviour, ISelectedCardPoolView
    {
        [SerializeField] private float tweenTime;
        [SerializeField] private TransformableView[] transformableViews;

        private ProductCardView[] _cardViews;

        public async UniTask StoreNewCard(ProductCardView cardView)
        {
            var storeTo = transformableViews[cardView.Card.PlayerId.Id];

            await cardView.ModelTransform
                .DOMove(storeTo.ModelTransform.position, tweenTime)
                .AsyncWaitForCompletion();
            _cardViews[cardView.Card.PlayerId.Id] = cardView;
        }

        public IReadOnlyList<ProductCardView> PopAllCardViews()
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
            _cardViews = new ProductCardView[transformableViews.Length];
        }
    }
}