using Gambit.Unity.Adapter.IView.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.IView.InGame.Ui
{
    public interface IStartTextView: ITransformableView
    {
        public Text Text { get; }
        public Vector3 CenterPosition { get; }
        public float MoveDuration { get; }
        public float FadeDuration { get; }
    }
}