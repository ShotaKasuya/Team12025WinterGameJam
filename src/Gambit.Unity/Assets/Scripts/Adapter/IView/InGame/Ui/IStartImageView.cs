using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.IView.InGame.Ui
{
    public interface IStartImageView : ITransformableView
    {
        public Image Image { get; }
        public Vector3 CenterPosition { get; }
        public float MoveDuration { get; }
        public float FadeDuration { get; }
    }

    public interface IStartEffectView
    {
        public UniTask ShowStart();
    }
}