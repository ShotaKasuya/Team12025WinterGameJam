using Gambit.Unity.Adapter.IView.InGame.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    [RequireComponent(typeof(Image))]
    public class ExplanationImageView:MonoBehaviour,IExplanationImageView
    {
            public Image Image { get; private set; }
            public float FadeInDuration => fadeInDuration;
            public float FadeOutDuration => fadeOutDuration;

            [SerializeField] private Vector3 centerPosition;
            [SerializeField] private float fadeInDuration;
            [SerializeField] private float fadeOutDuration;

            private void Awake()
            {
                Image = GetComponent<Image>();
            }
    }
}