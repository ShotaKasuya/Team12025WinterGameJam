using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

namespace Gambit.Unity.Adapter.IView.InGame.Ui
{
    public interface IExplanationImageView
    {
        public Image  Image { get; }
        public float FadeInDuration { get; }
        public float FadeOutDuration { get; }

    }
}