using Adapter.IView.InGame;
using Adapter.View.CardPrefabdb;
using UnityEngine;

namespace Adapter.View.InGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CardView: ProductCardView
    {
        [SerializeField] private Vector3 defaultScale;
        [SerializeField] private Vector3 selectedScale;
        [SerializeField] private CardSprites cardSprites;
        private Sprite _face;
        private Sprite _back;
        private SpriteRenderer _renderer;

        public override void ShowFace()
        {
            _renderer.sprite = _face;
        }

        public override void HideFace()
        {
            _renderer.sprite = _back;
        }

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

        protected override void Awake()
        {
            base.Awake();
            _renderer = GetComponent<SpriteRenderer>();
        }
    }
}