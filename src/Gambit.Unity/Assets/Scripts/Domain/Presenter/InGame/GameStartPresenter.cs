using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Domain.IPresenter.InGame;
using KanKikuchi.AudioManager;

namespace Gambit.Unity.Domain.Presenter.InGame
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

            SEManager.Instance.Play(SEPath.GAME_START_SE, 0.3f);
            await StartImageView.ModelTransform.DOMove(endPos, moveDuration).AsyncWaitForCompletion();

            await StartImageView.Image.DOFade(0, fadeDuration).AsyncWaitForCompletion();
            
        }

        private IStartImageView StartImageView { get; }
    }
}