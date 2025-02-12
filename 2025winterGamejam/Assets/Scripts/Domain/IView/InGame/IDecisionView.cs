using System;
using System.Collections.Generic;
using Structure.InGame;

namespace Domain.IView.InGame
{
    public interface IDecisionView
    {
        public Action<List<Card>> CardDecisionEvent { get; set; }
    }
    
    public class MockDecisionView : IDecisionView
    {
        public Action<List<Card>> CardDecisionEvent { get; set; }

        public void TriggerCardDecisionEvent(List<Card> cards)
        {
            CardDecisionEvent?.Invoke(cards);
        }
    } 
}