using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    [RequireComponent(typeof(Image))]
    public class StartImageView : MonoBehaviour, IStartImageView, IStartEffectView
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


        public async UniTask ShowStart()
        {
            SEManager.Instance.Play(SEPath.GAME_START_SE, 0.3f);
            await ModelTransform.DOMove(centerPosition, moveDuration).AsyncWaitForCompletion();

            await Image.DOFade(0, fadeDuration).AsyncWaitForCompletion();
        }
    }
}