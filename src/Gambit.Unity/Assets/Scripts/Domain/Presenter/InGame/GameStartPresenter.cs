using Adapter.IView.InGame.Ui;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Domain.IPresenter.InGame;

namespace Domain.Presenter.InGame
{
    /// <summary>
    /// ゲーム開始演出
    /// </summary>
    public class GameStartPresenter : IGameStartPresenter
    {
        public GameStartPresenter
        (
            IStartTextView startTextView
        )
        {
            StartTextView = startTextView;
        }

        public async UniTask GameStart()
        {
            var endPos = StartTextView.CenterPosition;
            var moveDuration = StartTextView.MoveDuration;
            var fadeDuration = StartTextView.FadeDuration;

            await StartTextView.ModelTransform.DOMove(endPos, moveDuration).AsyncWaitForCompletion();

            await StartTextView.Text.DOFade(0, fadeDuration).AsyncWaitForCompletion();
        }

        private IStartTextView StartTextView { get; }
    }
}