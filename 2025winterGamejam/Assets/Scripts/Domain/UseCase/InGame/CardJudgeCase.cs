using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domain.IModel.InGame.Judgement;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 勝敗をジャッジする
    /// </summary>
    public class CardJudgeCase : IAsyncStartable
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

        public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
        {
            while (true)
            {
                await UniTask.WaitUntil(() => SelectedCardModels.SelectedCards.All(x => x.IsSome), cancellationToken: cancellation);
                
                var selectedCards = SelectedCardModels.SelectedCards.Select(x => x.Unwrap());
                OnDecision(selectedCards.ToList());
            }
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
    }
}