using System;
using System.Collections.Generic;
using Domain.IModel.InGame;
using Domain.IView.InGame;
using Structure.InGame;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 勝敗をジャッジする
    /// </summary>
    public class CardJudgeCase: IDisposable
    {
        public CardJudgeCase
        (
            IDecisionView decisionView,
            IJudgeResultModel judgeResultModel
        )
        {
            decisionView.CardDecisionEvent += OnDecision;

            DecisionView = decisionView;
            JudgeResultModel = judgeResultModel;
        }

        private void OnDecision(List<Card> playerCard)
        {
            var result = Judge(playerCard);

            JudgeResultModel.StoreJudgeResult(result);
        }

        private BattleResult Judge(List<Card> playerCard)
        {
            // todo: 勝敗
            return BattleResult.Draw(playerCard);
        }

        private IDecisionView DecisionView { get; }
        private IJudgeResultModel JudgeResultModel { get; }

        public void Dispose()
        {
            DecisionView.CardDecisionEvent -= OnDecision;
        }
    }
}