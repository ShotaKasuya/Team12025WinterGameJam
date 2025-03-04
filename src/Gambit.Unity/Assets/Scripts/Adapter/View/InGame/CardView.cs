using Adapter.IView.InGame;
using UnityEngine;

namespace Adapter.View.InGame
{
    public class CardView: ProductCardView
    {
        [SerializeField] private Vector3 defaultScale;
        [SerializeField] private Vector3 selectedScale;

        private void OnMouseDown()
        {
            SelectionEvent?.Invoke(Card);
        }

        public override void TurnOn()
        {
            ModelTransform.localScale = selectedScale;
        }

        public override void TurnOff()
        {
            ModelTransform.localScale = defaultScale;
        }
    }
}