using Adapter.IView.InGame.Ui;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Domain.IPresenter.InGame;
using KanKikuchi.AudioManager;

namespace Domain.Presenter.InGame
{
    /// <summary>
    /// ゲーム開始演出
    /// </summary>
    public class GameStartPresenter : IGameStartPresenter
    {
        public GameStartPresenter
        (
            IStartImageView startImageView
        )
        {
            StartImageView = startImageView;
        }

        public async UniTask GameStart()
        {
            var endPos = StartImageView.CenterPosition;
            var moveDuration = StartImageView.MoveDuration;
            var fadeDuration = StartImageView.FadeDuration;

            SEManager.Instance.Play(SEPath.GAME_START_SE, 0.2f);

            await StartImageView.ModelTransform.DOMove(endPos, moveDuration).AsyncWaitForCompletion();
            await StartImageView.Image.DOFade(0, fadeDuration).AsyncWaitForCompletion();
        }

        private IStartImageView StartImageView { get; }
    }
}