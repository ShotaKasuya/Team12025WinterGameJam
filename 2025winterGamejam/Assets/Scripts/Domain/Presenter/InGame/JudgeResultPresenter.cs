using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Utility.Structure.InGame;

namespace Domain.Presenter.InGame
{
    public class JudgeResultPresenter : IJudgeResultPresenter
    {
        public JudgeResultPresenter
        (
            IDrawCardPoolView drawCardPoolView,
            IWinCardPoolView winCardPoolView,
            ISelectedCardPoolView selectedCardPoolView
        )
        {
            DrawCardPoolView = drawCardPoolView;
            WinCardPoolView = winCardPoolView;
            SelectedCardPoolView = selectedCardPoolView;
        }
        
        public async UniTask PresentResult(BattleResult result)
        {
            var views = SelectedCardPoolView.PopAllCardViews();
            // 勝者あり
            if (result.Winner.IsSome)
            {
                foreach (var cardView in views)
                {
                    await WinCardPoolView.StoreNewCard(cardView);
                }

                foreach (var cardView in DrawCardPoolView.PopAllCardViews())
                {
                    await WinCardPoolView.StoreNewCard(cardView);
                }

                return;
            }

            // 引き分け
            foreach (var cardView in views)
            {
                await DrawCardPoolView.StoreNewCard(cardView);
            }
        }

        private IDrawCardPoolView DrawCardPoolView { get; }
        private IWinCardPoolView WinCardPoolView { get; }
        private ISelectedCardPoolView SelectedCardPoolView { get; }
    }
}