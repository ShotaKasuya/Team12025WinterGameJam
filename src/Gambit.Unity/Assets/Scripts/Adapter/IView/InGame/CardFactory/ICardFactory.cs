using System;
using Adapter.IView.Utility;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.IView.InGame
{
    public interface ICardProduct: IHandCardView, ITransformableView
    {
    }
    /// <summary>
    /// カードのファクトリ
    /// </summary>
    public interface ICardFactory
    {
        public ProductCardView CreateCardView(PlayerCard playerCard);
    }
    public abstract class ProductCardView: MonoBehaviour, ICardProduct
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

        protected virtual void Awake()
        {
            ModelTransform = transform;
        }

        public abstract void ShowFace();
        public abstract void HideFace();
    
    }
}