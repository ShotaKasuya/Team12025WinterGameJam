using System;
using System.Collections.Generic;
using Domain.IView.InGame;
using Structure.InGame;
using UnityEngine;

namespace View.InGame
{
    public class Card: MonoBehaviour, IDecisionView
    {

        private void Start()
        {
            CardDecisionEvent.Invoke(null);
        }

        public Action<List<Structure.InGame.Card>> CardDecisionEvent { get; set; }
    }
}