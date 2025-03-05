using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Adapter.View.CardFactory;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CardView: ProductCardView
    {
        [SerializeField] private Vector3 defaultScale;
        [SerializeField] private Vector3 selectedScale;
        [SerializeField] private CardSprites cardSprites;
        private Sprite Face => cardSprites.GetCardSprite(Card.Card);
        private Sprite Back => cardSprites.CardBackSprite;
        private SpriteRenderer _renderer;

        public override void ShowFace()
        {
            _renderer.sprite = Face;
        }

        public override void HideFace()
        {
            _renderer.sprite = Back;
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