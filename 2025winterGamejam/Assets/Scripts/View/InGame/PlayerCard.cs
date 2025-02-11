using System;
using Domain.IView.InGame;
using Structure.InGame;
using UnityEngine;

namespace View.InGame
{
    public class PlayerCard: MonoBehaviour, IPlayerDecision
    {
        public Action<(Card, Card)> CardDecisionEvent { get; set; }

        private void Start()
        {
            CardDecisionEvent.Invoke((new Card(Suit.Clubs, Rank.Ace), new Card(Suit.Clubs, Rank.Ace)));
        }
    }
}