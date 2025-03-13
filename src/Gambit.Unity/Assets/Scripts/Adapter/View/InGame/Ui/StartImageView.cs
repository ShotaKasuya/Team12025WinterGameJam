using Gambit.Unity.Adapter.IView.InGame.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    [RequireComponent(typeof(Image))]
    public class StartImageView : MonoBehaviour, IStartImageView
    {
        public Transform ModelTransform { get; private set; }
        public Image Image { get; private set; }
        public Vector3 CenterPosition => new Vector3(0, 0, 0);
        public float MoveDuration => moveDuration;
        public float FadeDuration => fadeDuration;

        [SerializeField] private Vector3 centerPosition;
        [SerializeField] private float moveDuration;
        [SerializeField] private float fadeDuration;

        private void Awake()
        {
            ModelTransform = transform;
            Image = GetComponent<Image>();
        }
    }
}