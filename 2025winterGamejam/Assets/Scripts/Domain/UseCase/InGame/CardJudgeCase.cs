using System;
using System.Collections.Generic;
using Domain.IModel.InGame.Judgement;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 勝敗をジャッジする
    /// </summary>
    public class CardJudgeCase : IInitializable, IDisposable
    {
        public CardJudgeCase
        (
            ISelectedCardModel selectedCardModels,
            IJudgeResultModel judgeResultModel,
            IConditionModel conditionModel
        )
        {
            SelectedCardModels = selectedCardModels;
            JudgeResultModel = judgeResultModel;
            ConditionModel = conditionModel;
        }
        
        public void Initialize()
        {
            SelectedCardModels.OnSelectCompleted += OnDecision;
        }

        private void OnDecision(List<Card> playerCard)
        {
            for (int i = 0; i < playerCard.Count; i++)
            {
                var condition = ConditionModel.ConditionReader[i];
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
            if (playerCard[0].Rank == Rank.Two && playerCard[1].Rank == Rank.Ace)
                return BattleResult.Result(new PlayerId(0), playerCard);
            else if (playerCard[0].IsGreater(playerCard[1]))
                return BattleResult.Result(new PlayerId(0), playerCard);
            else if (playerCard[1].IsGreater(playerCard[0]))
                return BattleResult.Result(new PlayerId(1), playerCard);
            else
                return BattleResult.Draw(playerCard);
        }

        private ISelectedCardModel SelectedCardModels { get; }
        private IJudgeResultModel JudgeResultModel { get; }
        private IConditionModel ConditionModel { get; }


        public void Dispose()
        {
            SelectedCardModels.OnSelectCompleted -= OnDecision;
        }
    }
}