using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame.CardPool
{
    public class WinCardPoolView : MonoBehaviour, IWinCardPoolView
    {
        [SerializeField] private Transform[] cardPositions;
        [SerializeField] private float moveDuration;

        private List<ProductCardView> _winCardViews = new List<ProductCardView>();
        private List<ProductCardView> _bufferCards = new List<ProductCardView>();
        private Vector3 Positions(PlayerId index) => cardPositions[index.Id].position;
        private float MoveDuration => moveDuration;

        public async UniTask StoreNewCard(ProductCardView cardView)
        {
            _winCardViews.Add(cardView);
            await cardView.ModelTransform.DOMove(Positions(cardView.Card.PlayerId), MoveDuration)
                .AsyncWaitForCompletion();
        }

        public IReadOnlyList<ProductCardView> PopAllCardViews(PlayerId playerId)
        {
            var tmp = _winCardViews;
            _bufferCards.Clear();
            _winCardViews = _bufferCards;
            _bufferCards = tmp;
            return _bufferCards;
        }
    }
}