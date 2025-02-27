using System.Linq;
using Adapter.IModel.Global;
using Adapter.IModel.InGame;
using Adapter.IModel.InGame.Judgement;
using Domain.IUseCase.InGame;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame
{
    public class AddPointCase : IAddPointCase
    {
        public AddPointCase
        (
            IPlayerCountModel playerCountModel,
            IScoreModel scoreModel,
            ITmpJudgeResultModel judgeResultModel,
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
                ScoreModel.AddScore(i, point);
            }

            return points;
        }

        private int CalcPoint(int target, ResultAndDrawCount resultAndDrawCount)
        {
            var basePoint = 2 * (resultAndDrawCount.DrawCount + 1);
            var targetCondition = ConditionModel.ConditionReader[target];
            var targetCard = resultAndDrawCount.BattleResult.Cards[target];

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
            }

            // 自身が弱体化しているかの確認
            if ((targetCondition & Condition.Ten) != 0)
            {
                basePoint /= 2;
            }

            // 特殊効果が無効化されているときの処理
            if (targetCondition == Condition.Six)
            {
                return basePoint;
            }

            return targetCard.Rank switch
            {
                Rank.Seven => basePoint * RankDifference(target, resultAndDrawCount),
                Rank.Nine => basePoint + 2,
                Rank.Jack => basePoint + 4,
                _ => basePoint
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
        private ITmpJudgeResultModel JudgeResultModel { get; }
        private IConditionModel ConditionModel { get; }
    }
}