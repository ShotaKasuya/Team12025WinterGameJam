using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Structure.Utility.InGame;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Controller.InGame
{
    /// <summary>
    /// カーソルが上に存在するカードの効果説明を表示する
    /// </summary>
    public class CardExplanationController : IInitializable, IDisposable
    {
        public CardExplanationController
        (
            IPlayerIdModel playerIdModel,
            IHandCardPoolView handCardPoolView,
            IExplanationImageView explanationImageView
        )
        {
            PlayerIdModel = playerIdModel;
            HandCardPoolView = handCardPoolView;
            ExplanationImageView = explanationImageView;
        }

        public void Initialize()
        {
            HandCardPoolView.OnStore += SetLinker;
            HandCardPoolView.OnPop += RemoveLinker;
        }

        private void SetLinker(ProductCardView view)
        {
            view.CursorOverrideEvent += OnOverride;
            view.CursorExitEvent += OnExit;
        }

        private void RemoveLinker(ProductCardView view)
        {
            view.CursorOverrideEvent -= OnOverride;
            view.CursorExitEvent -= OnExit;
        }

        private void OnOverride(PlayerCard card)
        {
            var id = PlayerIdModel.PlayerId;
            if (card.PlayerId == id)
            {
                var _ = FadeInExplain(card.Card);
            }
        }

        private void OnExit(PlayerCard card)
        {
            var id = PlayerIdModel.PlayerId;
            if (card.PlayerId == id)
            {
                var _ = FadeOutExplain(card.Card);
            }
        }

        private async UniTask FadeInExplain(Card card)
        {
            var fadeInDuration = ExplanationImageView.FadeInDuration;
            var explanationImage = ExplanationImageView.Image;
            ExplanationImageView.Face(card);

            await explanationImage.DOFade(1, fadeInDuration).AsyncWaitForCompletion();
        }

        private async UniTask FadeOutExplain(Card card)
        {
            if (ExplanationImageView.PrevCard != card)
            {
                return;
            }

            var fadeOutDuration = ExplanationImageView.FadeOutDuration;
            var explanationImage = ExplanationImageView.Image;
            await explanationImage.DOFade(0, fadeOutDuration).AsyncWaitForCompletion();
        }

        private IPlayerIdModel PlayerIdModel { get; }
        private IExplanationImageView ExplanationImageView { get; }
        private IHandCardPoolView HandCardPoolView { get; }

        public void Dispose()
        {
            HandCardPoolView.OnStore -= SetLinker;
            HandCardPoolView.OnPop -= RemoveLinker;
        }
    }
}