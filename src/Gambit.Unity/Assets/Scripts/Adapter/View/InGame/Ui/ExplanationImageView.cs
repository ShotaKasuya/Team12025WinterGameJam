using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    [RequireComponent(typeof(Image))]
    public class ExplanationImageView : MonoBehaviour, IExplanationImageView
    {
        public Image Image { get; private set; }
        public float FadeInDuration => fadeInDuration;
        public float FadeOutDuration => fadeOutDuration;
        public Card PrevCard { get; private set; }

        [SerializeField] private float fadeInDuration;
        [SerializeField] private float fadeOutDuration;
        [SerializeField] private ExplanationSprites explanationSprites;

        private void Awake()
        {
            Image = GetComponent<Image>();
        }

        public void Face(Card card)
        {
            PrevCard = card;
            Image.sprite = explanationSprites.GetImage(card);
        }
    }
}