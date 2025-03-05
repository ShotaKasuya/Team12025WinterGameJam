using UnityEngine.UI;

namespace Gambit.Unity.Adapter.IView.InGame.Ui
{
    public interface IAddPointTextView
    {
        public Text Text { get; }
        public float FadeInDuration { get; }
        public float FadeOutDuration { get; }
    }
}