using System;
using System.Collections.Generic;
using UnityEngine;
using Utility.Structure.InGame;

namespace IView.InGame
{
    public interface ICardFactory
    {
        public FactoryProductCardView CreateCardView(Card card);
    }

    public interface ICardProduct: ISelectionView
    {
        public void Inject(PlayerHandCard id, Action<FactoryProductCardView> disposable);
    }

    public abstract class FactoryProductCardView: MonoBehaviour, ICardProduct
    {
        public Action<List<Card>> CardDecisionEvent { get; set; }
        protected PlayerHandCard Card { get; private set; }
        private Action<FactoryProductCardView> _disposable;
        public void Inject(PlayerHandCard id, Action<FactoryProductCardView> disposable)
        {
            Card = id;
            _disposable = disposable;
        }

        private void OnDestroy()
        {
            _disposable.Invoke(this);
        }
    }
}