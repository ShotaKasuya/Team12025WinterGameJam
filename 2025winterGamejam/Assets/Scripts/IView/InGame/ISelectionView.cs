using System;
using System.Collections.Generic;
using Structure.InGame;
using UnityEngine;

namespace IView.InGame
{
    public interface ISelectionView
    {
        public Action<List<Card>> CardDecisionEvent { get; set; }
    }

    public interface IHandCardView
    {
        /// <summary>
        /// 手札が選択されたイベント
        /// </summary>
        public Action<PlayerHandCard> SelectionEvent { get; set; }
    }

    public abstract class FactorableCardView : MonoBehaviour, IHandCardView, ICardView
    {
        private void Awake()
        {
            ModelTransform = transform;
        }

        public Transform ModelTransform { get; private set; }
        public Action<PlayerHandCard> SelectionEvent { get; set; }
        protected PlayerHandCard Card { get; private set; }
        private Action<FactorableCardView> _dispose;
        public void InitHandCard(PlayerHandCard id, Action<FactorableCardView> disposable)
        {
            Card = id;
            _dispose = disposable;
        }

        private void OnDestroy()
        {
            _dispose.Invoke(this);
        }
    }

    public class MockSelectionView : ISelectionView
    {
        public Action<List<Card>> CardDecisionEvent { get; set; }

        public void TriggerCardDecisionEvent(List<Card> cards)
        {
            CardDecisionEvent?.Invoke(cards);
        }
    } 
}