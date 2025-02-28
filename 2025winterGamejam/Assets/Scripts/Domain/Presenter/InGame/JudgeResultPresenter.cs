using System;
using System.Linq;
using Adapter.IModel.InGame.Judgement;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.Presenter.InGame
{
    public class JudgeResultPresenter : IInitializable, IDisposable, IJudgeResultPresenter
    {
        public JudgeResultPresenter
        (
            IJudgeEventModel judgeEventModel,
            ISelectedCardModel selectedCardModel,
            IDrawCardPoolView drawCardPoolView,
            IWinCardPoolView winCardPoolView,
            IHandCardPoolView handCardPoolView
        )
        {
            JudgeEventModel = judgeEventModel;
            SelectedCardModel = selectedCardModel;
            DrawCardPoolView = drawCardPoolView;
            WinCardPoolView = winCardPoolView;
            HandCardPoolView = handCardPoolView;
        }

        public void Initialize()
        {
            JudgeEventModel.JudgeEndEvent += OnJudge;
        }

        private void OnJudge(ResultAndDrawCount result)
        {
            // 勝者あり
            if (result.BattleResult.Winner.TryGetValue(out var id))
            {
                return;
            }

            // 引き分け
        }

        private IJudgeEventModel JudgeEventModel { get; }
        private ISelectedCardModel SelectedCardModel { get; }
        private IDrawCardPoolView DrawCardPoolView { get; }
        private IWinCardPoolView WinCardPoolView { get; }
        private IHandCardPoolView HandCardPoolView { get; }

        public void Dispose()
        {
            JudgeEventModel.JudgeEndEvent -= OnJudge;
        }

        public async UniTask PresentResult(BattleResult result)
        {
            var views = result.Cards.Select(x => HandCardPoolView.PopCardView(new PlayerCard())).ToList();
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
    }
}