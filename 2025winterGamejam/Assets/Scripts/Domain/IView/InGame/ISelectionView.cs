using System;
using System.Collections.Generic;
using Structure.InGame;
using UnityEngine;

namespace Domain.IView.InGame
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
        public Action<PlayerHandCard> SelectionEvent { get; }
    }

    public abstract class FactorableCardView : MonoBehaviour
    {
        protected PlayerHandCard Card { get; private set; }
        public void InitHandCard(PlayerHandCard id)
        {
            Card = id;
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