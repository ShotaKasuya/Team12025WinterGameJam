using System;
using Structure.InGame;

namespace Domain.IModel.InGame
{
    /// <summary>
    /// カードに対する勝敗処理結果が保存された際のイベント
    /// </summary>
    public interface IJudgeEventModel
    {
        Action<BattleResult> JudgeEndEvent { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IJudgeResultModel
    {
        public void StoreJudgeResult(BattleResult battleResult);
    }
    
    
    public class MockJudgeResultModel : IJudgeResultModel
    {
        public BattleResult StoredResult { get; private set; }

        public void StoreJudgeResult(BattleResult result)
        {
            StoredResult = result;
        }
    }
}