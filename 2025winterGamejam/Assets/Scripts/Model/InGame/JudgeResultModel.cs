using System;
using System.Collections.Generic;
using Domain.IModel.InGame;
using Utility.Structure.InGame;

namespace Model.InGame
{
    public class JudgeResultModel : IJudgeEventModel, IJudgeResultModel
    {
        private List<BattleResult> BattleResults { get; } = new List<BattleResult>(13);
        public Action<ResultAndDrawCount> JudgeEndEvent { get; set; }

        public void StoreJudgeResult(BattleResult battleResult)
        {
            int drawCount = 0;
            var length = BattleResults.Count - 1;
            for (; drawCount < length; drawCount++)
            {
                if (BattleResults[length - drawCount].Winner.IsSome)
                {
                    break;
                }
            }

            BattleResults.Add(battleResult);

            JudgeEndEvent?.Invoke(new ResultAndDrawCount(drawCount, battleResult));
        }
    }
}