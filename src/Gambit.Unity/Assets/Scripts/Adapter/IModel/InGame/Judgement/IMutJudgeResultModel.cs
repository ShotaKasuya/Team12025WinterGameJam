using System;
using System.Collections.Generic;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Judgement
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
    public interface IMutJudgeResultModel
    {
        public void StoreJudgeResult(BattleResult battleResult);
    }
    public interface IJudgeResultModel
    {
        public IReadOnlyList<BattleResult> BattleResults { get; }
        public ResultAndDrawCount LastResults { get; }
    }
    
    public class MockJudgeResultModel : IMutJudgeResultModel
    {
        public BattleResult StoredResult { get; private set; }

        public void StoreJudgeResult(BattleResult result)
        {
            StoredResult = result;
        }
    }
}