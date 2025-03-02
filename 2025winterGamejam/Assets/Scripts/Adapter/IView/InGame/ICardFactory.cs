using System;
using System.Collections.Generic;
using Adapter.IView.Utility;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.IView.InGame
{
    public interface ICardFactory
    {
        public ProductCardView CreateCardView(Card card);
        public IReadOnlyList<ProductCardView> Products { get; }
        public Action<ProductCardView> OnCreateView { get; set; }
    }

    public interface ICardReleaseView
    {
        public void Release(PlayerId playerId, Card card);
    }

    public interface ICardProduct: IHandCardView, ITransformableView
    {
    }

    public abstract class ProductCardView: MonoBehaviour, ICardProduct
    {
        public Transform ModelTransform { get; private set; }
        public Action<PlayerCard> SelectionEvent { get; set; }
        public abstract void TurnOn();
        public abstract void TurnOff();

        public Card Card { get; private set; }
        private Action<ProductCardView> _disposable;
        public void Inject(Card card, Action<ProductCardView> disposable)
        {
            Card = card;
            _disposable = disposable;
        }

        private void Awake()
        {
            ModelTransform = transform;
        }
        private void OnDestroy()
        {
            _disposable.Invoke(this);
        }
    }
    
    /// <summary>
    /// カードのファクトリ
    /// </summary>
    public interface INewCardFactory
    {
        public NewProductCardView CreateCardView(PlayerCard playerCard);
    }
    public abstract class NewProductCardView: MonoBehaviour, ICardProduct
    {
        public Transform ModelTransform { get; private set; }
        public Action<PlayerCard> SelectionEvent { get; set; }
        public abstract void TurnOn();
        public abstract void TurnOff();

        public PlayerCard Card { get; private set; }
        public void Inject(PlayerCard card)
        {
            Card = card;
        }

        private void Awake()
        {
            ModelTransform = transform;
        }
    }
}