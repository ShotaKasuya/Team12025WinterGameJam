using System.Linq;
using Adapter.IModel.InGame.Judgement;
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
            IJudgeEventModel judgeEventModel,
            IDrawCardPoolView drawCardPoolView,
            IWinCardPoolView winCardPoolView,
            IHandCardPoolView handCardPoolView
        )
        {
            JudgeEventModel = judgeEventModel;
            DrawCardPoolView = drawCardPoolView;
            WinCardPoolView = winCardPoolView;
            HandCardPoolView = handCardPoolView;
        }
        
        public async UniTask PresentResult(BattleResult result)
        {
            var views = result.Cards.Select(x => HandCardPoolView.PopCardView(x)).ToList();
            // 勝者あり
            if (result.Winner.TryGetValue(out var id))
            {
                foreach (var cardView in views)
                {
                    await WinCardPoolView.StoreNewCard(id, cardView);
                }

                return;
            }

            // 引き分け
            foreach (var cardView in views)
            {
                await DrawCardPoolView.StoreNewCard(id, cardView);
            }
        }

        private IJudgeEventModel JudgeEventModel { get; }
        private IDrawCardPoolView DrawCardPoolView { get; }
        private IWinCardPoolView WinCardPoolView { get; }
        private IHandCardPoolView HandCardPoolView { get; }
    }
}