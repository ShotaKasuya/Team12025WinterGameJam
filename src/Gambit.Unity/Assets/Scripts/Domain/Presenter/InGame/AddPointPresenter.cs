using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Domain.IPresenter.InGame;

namespace Gambit.Unity.Domain.Presenter.InGame
{
    // <summary>
    // 加点時演出
    // </summary>
    public class AddPointPresenter : IAddPointPresenter
    {
        public AddPointPresenter
        (
            IAddPointTextView addPointTextView
        )
        {
            AddPointTextView = addPointTextView;
        }

        public async UniTask PresentAddPoint(int[] points)
        {
            var fadeInDuration = AddPointTextView.FadeInDuration;
            var fadeOutDuration = AddPointTextView.FadeOutDuration;
            var pointText = AddPointTextView.Text;
            pointText.text = "";

            for (int i = 0; i < points.Length; i++)
            {
                if (i != 0)
                {
                    pointText.text += " vs ";
                }

                pointText.text += points[i];
            }

            await pointText.DOFade(1, fadeInDuration).AsyncWaitForCompletion();

            await pointText.DOFade(0, fadeOutDuration).AsyncWaitForCompletion();
        }

        private IAddPointTextView AddPointTextView { get; }
    }
}