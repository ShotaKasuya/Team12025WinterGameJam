using Adapter.IView.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.IView.InGame.Ui
{
    public interface IStartTextView: ITransformableView
    {
        public Text Text { get; }
        public Vector3 CenterPosition { get; }
        public float MoveDuration { get; }
        public float FadeDuration { get; }
    }
}