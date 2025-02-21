using System;
using System.Collections.Generic;
using System.Linq;
using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using R3;
using Utility.Structure.InGame;
using ISelectedCardModel = Domain.IModel.InGame.Player.ISelectedCardModel;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 勝敗をジャッジする
    /// </summary>
    public class CardJudgeCase : IDisposable
    {
        public CardJudgeCase
        (
            ISelectedCardModel[] selectedCardModels,
            IJudgeResultModel judgeResultModel,
            IConditionModel[] playerConditionModel
        )
        {
            SelectedCardModels = selectedCardModels;
            JudgeResultModel = judgeResultModel;
            PlayerConditionModel = playerConditionModel;
            Disposable = new CompositeDisposable();

            foreach (var selectedCardModel in SelectedCardModels)
            {
                selectedCardModel.OnSelected
                    .Subscribe(_ => { CheckDecision(); })
                    .AddTo(Disposable);
            }
        }

        private void CheckDecision()
        {
            var length = SelectedCardModels.Length;
            var hasDecided = SelectedCardModels
                .Count(x => x.OnSelected.CurrentValue.IsSome);
            if (length == hasDecided)
            {
                var playerCards = SelectedCardModels
                    .Select(x => x.OnSelected.CurrentValue.Unwrap())
                    .ToList();
                OnDecision(playerCards);
            }
        }

        private void OnDecision(List<Card> playerCard)
        {
            for (int i = 0; i < playerCard.Count; i++)
            {
                var condition = PlayerConditionModel[i].Condition;
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

        private ISelectedCardModel[] SelectedCardModels { get; }
        private IJudgeResultModel JudgeResultModel { get; }
        private IConditionModel[] PlayerConditionModel { get; }
        private CompositeDisposable Disposable { get; }

        public void Dispose()
        {
            Disposable?.Dispose();
        }
    }
}