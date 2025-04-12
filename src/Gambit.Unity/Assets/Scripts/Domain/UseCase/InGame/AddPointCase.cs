using System.Linq;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Domain.UseCase.InGame
{
    public class AddPointCase : IAddPointCase
    {
        public AddPointCase
        (
            IPlayerCountModel playerCountModel,
            IScoreModel scoreModel,
            IJudgeResultModel judgeResultModel,
            IConditionModel conditionModel
        )
        {
            PlayerCountModel = playerCountModel;
            ScoreModel = scoreModel;
            JudgeResultModel = judgeResultModel;
            ConditionModel = conditionModel;
        }

        public int[] AddPoint()
        {
            var points = new int[PlayerCountModel.PlayerCount];
            var result = JudgeResultModel.LastResults;
            for (var i = 0; i < points.Length; i++)
            {
                var point = CalcPoint(i, result);
                points[i] = point;
                ScoreModel.AddScore(new PlayerId(i), point);
            }

            Debug.Log($"1: {points[0]}, 2: {points[1]}");

            return points;
        }

        private int CalcPoint(int target, ResultAndDrawCount resultAndDrawCount)
        {
            var basePoint = 2 * (resultAndDrawCount.DrawCount + 1);     // カードの枚数
            var targetCondition = ConditionModel.ConditionReader[target];
            var targetCard = resultAndDrawCount.BattleResult.Cards[target];
            int Debuf = 1;

            // 勝者なし
            if (!resultAndDrawCount.BattleResult.Winner.TryGetValue(out var winner))
            {
                return 0;
            }

            if (target != winner.Id)
            {
                // `J`で負けるとマイナス
                if (targetCard.Rank == Rank.Jack)
                {
                    return -4;
                }

                return 0;
            }

            // 自身が弱体化しているかの確認
            if ((targetCondition & Condition.Ten) != 0)
            {
                Debuf = 2;
            }

            // 特殊効果が無効化されているときの処理
            if (targetCondition == Condition.Six)
            {
                return basePoint;
            }

            return targetCard.Rank switch
            {
                Rank.Two => (basePoint + 8)/Debuf,
                Rank.Seven => basePoint * RankDifference(target, resultAndDrawCount)/Debuf,
                Rank.Nine => (basePoint + 2)/Debuf,
                Rank.Jack => (basePoint + 4)/Debuf,
                _ => basePoint/Debuf
            };
        }

        // 7勝利時の相手とのランク差を計算する処理
        private static int RankDifference(int target, ResultAndDrawCount resultAndDrawCount)
        {
            var myRank = resultAndDrawCount.BattleResult.Cards[target].Rank;

            return (int)myRank -
                   (int)resultAndDrawCount.BattleResult.Cards
                       .Select(x => x.Rank)
                       .Where(x => x != myRank)
                       .Max();
        }

        private IPlayerCountModel PlayerCountModel { get; }
        private IScoreModel ScoreModel { get; }
        private IJudgeResultModel JudgeResultModel { get; }
        private IConditionModel ConditionModel { get; }
    }
}