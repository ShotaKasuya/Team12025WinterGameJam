using System;
using System.Collections.Generic;
using System.Linq;
using Adapter.IModel.InGame.Judgement;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame.Judgement
{
    public class JudgeResultModel : IJudgeEventModel, IMutJudgeResultModel, IJudgeResultModel
    {
        private List<BattleResult> BattleResults { get; } = new List<BattleResult>(13);
        IReadOnlyList<BattleResult> IJudgeResultModel.BattleResults => BattleResults;

        public Action<ResultAndDrawCount> JudgeEndEvent { get; set; }
        public ResultAndDrawCount LastResults
        {
            get
            {
                int drawCount = 0;
                for (int i = BattleResults.Count - 1; i >= 0; i--)
                {
                    if (BattleResults[i].Winner.IsSome)
                    {
                        break;
                    }

                    drawCount++;
                }

                return new ResultAndDrawCount(drawCount, BattleResults.Last());
            }
        }


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

            Debug.Log($"current : {battleResult}");

            JudgeEndEvent?.Invoke(new ResultAndDrawCount(drawCount, battleResult));
        }
    }
}