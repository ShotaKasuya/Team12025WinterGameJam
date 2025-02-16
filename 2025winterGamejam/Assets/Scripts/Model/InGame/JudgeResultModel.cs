using System;
using Domain.IModel.InGame;
using Structure.InGame;

namespace Model.InGame
{
    public class JudgeResultModel: IJudgeEventModel, IJudgeResultModel
    {
        public Action<BattleResult> JudgeEndEvent { get; set; }
        public void StoreJudgeResult(BattleResult battleResult)
        {
            JudgeEndEvent?.Invoke(battleResult);
        }
    }
}