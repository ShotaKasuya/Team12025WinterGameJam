using System;
using Gambit.Unity.Adapter.IView.Utility;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.IView.InGame.CardFactory
{
    public interface ICardProduct: IHandCardView, ICursorOverrideEventView, ITransformableView
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
        public Action<PlayerCard> CursorOverrideEvent { get; set; }
        public Action<PlayerCard> CursorExitEvent { get; set; }
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