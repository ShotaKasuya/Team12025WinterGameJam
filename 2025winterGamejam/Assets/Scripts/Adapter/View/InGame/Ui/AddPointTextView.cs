using Adapter.IView.InGame.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.View.InGame.Ui
{
    public class AddPointTextView : MonoBehaviour, IAddPointTextView
    {

        public Text Text { get; private set; }
        public float FadeInDuration => fadeInDuration;
        public float FadeOutDuration => fadeOutDuration;

        [SerializeField] private float fadeInDuration;
        [SerializeField] private float fadeOutDuration;

    }
}