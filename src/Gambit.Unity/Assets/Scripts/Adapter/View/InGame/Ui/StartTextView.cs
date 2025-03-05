using Gambit.Unity.Adapter.IView.InGame.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    [RequireComponent(typeof(Text))]
    public class StartTextView : MonoBehaviour, IStartTextView
    {
        public Transform ModelTransform { get; private set; }
        public Text Text { get; private set; }
        public Vector3 CenterPosition => new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        public float MoveDuration => moveDuration;
        public float FadeDuration => fadeDuration;

        [SerializeField] private Vector3 centerPosition;
        [SerializeField] private float moveDuration;
        [SerializeField] private float fadeDuration;

        private void Awake()
        {
            ModelTransform = transform;
            Text = GetComponent<Text>();
        }
    }
}