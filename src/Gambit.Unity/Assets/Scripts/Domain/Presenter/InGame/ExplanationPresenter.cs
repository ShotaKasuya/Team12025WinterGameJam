using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Domain.IPresenter.InGame;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Gambit.Unity.Domain.Presenter.InGame
{
    public class ExplanationPresenter:IExplanationPresenter
    {
        public ExplanationPresenter
        (
            IExplanationImageView explanationImageView
        )
        {
            ExplanationImageView = explanationImageView;
        }

        public async UniTask OnMouseEnter()
        {
            
            ExplanationImageView.Face();
            var fadeInDuration = ExplanationImageView.FadeInDuration;
            var explanationImageView = ExplanationImageView.Image;
            
            await explanationImageView.DOFade(1, fadeInDuration).AsyncWaitForCompletion();

        }

        public async UniTask OnMouseExit()
        {
            var fadeOutDuration = ExplanationImageView.FadeOutDuration;
            var explanationImageView = ExplanationImageView.Image;
            
            await explanationImageView.DOFade(0, fadeOutDuration).AsyncWaitForCompletion();
        }
        
        private IExplanationImageView ExplanationImageView { get; }
    }
}