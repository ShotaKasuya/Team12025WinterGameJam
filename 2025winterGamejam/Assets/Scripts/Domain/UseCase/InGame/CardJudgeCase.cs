using System;
using System.Collections.Generic;
using Domain.IModel.InGame;
using IView.InGame;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 勝敗をジャッジする
    /// </summary>
    public class CardJudgeCase: IDisposable
    {
        public CardJudgeCase
        (
            ISelectionView selectionView,
            IJudgeResultModel judgeResultModel,
            IPlayerConditionModel playerConditionModel
        )
        {
            selectionView.CardDecisionEvent += OnDecision;

            SelectionView = selectionView;
            JudgeResultModel = judgeResultModel;
            PlayerConditionModel = playerConditionModel;
        }

        private void OnDecision(List<Card> playerCard)
        {
            for (int i = 0; i < playerCard.Count; i++)
            {
                var condition = PlayerConditionModel.PlayerConditions[i];
                if ((condition & Condition.Five) != 0)
                {
                    playerCard[i].SetDebuff(5);
                }
            }
            var result = Judge(playerCard);

            JudgeResultModel.StoreJudgeResult(result);
        }

        private BattleResult Judge(List<Card> playerCard)
        {
            // todo: 勝敗
            if (playerCard[0].Rank == Rank.Two && playerCard[1].Rank == Rank.Ace)
                return BattleResult.Result(new PlayerId(0), playerCard);
            else
                if(playerCard[0].IsGreater(playerCard[1]))
                    return BattleResult.Result(new PlayerId(0), playerCard);
                else if (playerCard[1].IsGreater(playerCard[0]))
                    return BattleResult.Result(new PlayerId(1), playerCard);
                else
                    return BattleResult.Draw(playerCard);
        }

        private ISelectionView SelectionView { get; }
        private IJudgeResultModel JudgeResultModel { get; }
        private IPlayerConditionModel PlayerConditionModel { get; }

        public void Dispose()
        {
            SelectionView.CardDecisionEvent -= OnDecision;
        }
    }
}