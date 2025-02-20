using System;
using System.Collections.Generic;
using IView.Utility;
using UnityEngine;
using Utility.Structure.InGame;

namespace IView.InGame
{
    public interface ICardFactory
    {
        public ProductCardView CreateCardView(Card card);
        public IReadOnlyList<ProductCardView> Products { get; }
        public Action<ProductCardView> OnCreateView { get; set; }
    }

    public interface ICardProduct: ISelectionView, ITransformableView
    {
        public void Inject(Card card, Action<ProductCardView> disposable);
    }

    public abstract class ProductCardView: MonoBehaviour, ICardProduct
    {
        private void Awake()
        {
            ModelTransform = transform;
        }
        public Transform ModelTransform { get; private set; }
        public Action<List<Card>> CardDecisionEvent { get; set; }
        protected Card Card { get; private set; }
        private Action<ProductCardView> _disposable;
        public void Inject(Card card, Action<ProductCardView> disposable)
        {
            Card = card;
            _disposable = disposable;
        }

        private void OnDestroy()
        {
            _disposable.Invoke(this);
        }

    }
}