using System.Collections.Generic;
using System.Linq;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.UseCase.InGame
{
    /// <summary>
    /// 勝敗をジャッジする
    /// </summary>
    public class CardJudgeCase : IJudgeCase
    {
        public CardJudgeCase
        (
            ISelectedCardModel selectedCardModels,
            IConditionModel conditionModel,
            IMutJudgeResultModel judgeResultModel
        )
        {
            SelectedCardModels = selectedCardModels;
            ConditionModel = conditionModel;
            JudgeResultModel = judgeResultModel;
        }

        public BattleResult Judge()
        {
            var selectedCards = SelectedCardModels
                .SelectedCards.Select(x => x.Unwrap()).ToList();
            SelectedCardModels.Clear();
            
            for (var i = 0; i < selectedCards.Count; i++)
            {
                var condition = ConditionModel.ConditionReader[i];
                if ((condition & Condition.Five) != 0)
                {
                    selectedCards[i].Card.SetDebuff(5);
                }
            }

            var result = Judge(selectedCards);
            JudgeResultModel.StoreJudgeResult(result);
            return result;
        }

        private BattleResult Judge(List<PlayerCard> playerCard)
        {
            if (playerCard[0].Card.Rank == Rank.Two && playerCard[1].Card.Rank == Rank.Ace)
                return BattleResult.Result(new PlayerId(0), playerCard);
            else if (playerCard[0].IsGreater(playerCard[1]))
                return BattleResult.Result(new PlayerId(0), playerCard);
            else if (playerCard[1].IsGreater(playerCard[0]))
                return BattleResult.Result(new PlayerId(1), playerCard);
            else
                return BattleResult.Draw(playerCard);
        }

        private ISelectedCardModel SelectedCardModels { get; }
        private IConditionModel ConditionModel { get; }
        private IMutJudgeResultModel JudgeResultModel { get; }
    }
}