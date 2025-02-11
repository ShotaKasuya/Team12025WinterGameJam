using System;
using Structure.InGame;

namespace Domain.IView.InGame
{
    public interface IPlayerDecision
    {
        public Action<(Card, Card)> CardDecisionEvent { get; set; }
    }
}