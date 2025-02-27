using System;
using System.Collections.Generic;
using System.Linq;
using Adapter.IModel.InGame.Judgement;
using Adapter.IView.InGame;
using VContainer.Unity;

namespace Domain.Presenter.InGame
{
    public class JudgeResultPresenter : IInitializable, IDisposable
    {
        public JudgeResultPresenter
        (
            IJudgeEventModel judgeEventModel,
            ISelectedCardModel selectedCardModel,
            IDrawCardPoolView cardPoolView,
            IHandCardInstanceView handCardInstanceView
        )
        {
            JudgeEventModel = judgeEventModel;
            SelectedCardModel = selectedCardModel;
            DrawCardPoolView = cardPoolView;
            HandCardInstanceView = handCardInstanceView;
        }

        public void Initialize()
        {
            JudgeEventModel.JudgeEndEvent += OnJudge;
        }

        private void OnJudge(ResultAndDrawCount result)
        {
            var views = result.BattleResult.Cards.Select(x => HandCardInstanceView.GetInstance(x)).ToList();
            if (result.BattleResult.Winner.IsSome)
            {
                OnResult(views);
                return;
            }

            OnDraw(views);
        }

        private void OnDraw(IReadOnlyList<ProductCardView> selectedCards)
        {
            foreach (var cardView in selectedCards)
            {
                DrawCardPoolView.StoreNewCard(cardView);
            }
        }

        private void OnResult(IReadOnlyList<ProductCardView> selectedCards)
        {
        }

        private IJudgeEventModel JudgeEventModel { get; }
        private ISelectedCardModel SelectedCardModel { get; }
        private IDrawCardPoolView DrawCardPoolView { get; }
        private IHandCardInstanceView HandCardInstanceView { get; }

        public void Dispose()
        {
            JudgeEventModel.JudgeEndEvent -= OnJudge;
        }
    }
}