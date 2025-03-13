using System.Collections.Generic;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Judgement
{
    /// <summary>
    /// 各プレイヤーの状態異常
    /// </summary>
    public interface IMutConditionModel: IConditionModel
    {
        public void SetCondition(int playerId, Condition condition);
    }
    
    public interface IConditionModel
    {
        public IReadOnlyList<Condition> ConditionReader { get; }
    }
}