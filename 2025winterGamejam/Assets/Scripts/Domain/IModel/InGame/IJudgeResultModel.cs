using System;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame
{
    /// <summary>
    /// カードに対する勝敗処理結果が保存された際のイベント
    /// </summary>
    public interface IJudgeEventModel
    {
        Action<ResultAndDrawCount> JudgeEndEvent { get; set; }
    }
    public struct ResultAndDrawCount
    {
        public ResultAndDrawCount(int drawCount,BattleResult battleResult)
        {
            DrawCount = drawCount;
            BattleResult = battleResult;
        }
        public int DrawCount {get;}
        public BattleResult BattleResult{get;}
    }
    public class MockJudgeEventModel : IJudgeEventModel
    {
        public Action<ResultAndDrawCount> JudgeEndEvent { get; set; }

        public void InvokeJudgeEndEvent(ResultAndDrawCount resultAndDrawCount)
        {
            JudgeEndEvent.Invoke(resultAndDrawCount);
        }
    }

    /// <summary>
    /// 勝敗結果を保存するモデル
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