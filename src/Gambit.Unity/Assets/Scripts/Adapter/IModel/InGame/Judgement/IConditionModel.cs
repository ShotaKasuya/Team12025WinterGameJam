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
        public class MockConditionModel : IMutConditionModel
    {
        public IReadOnlyList<Condition> ConditionReader => Conditions;
        public Condition[] Conditions {get;}

        public MockConditionModel
        (
            int playerCount
        )
        {
            Conditions = new Condition[playerCount];
        }
        public void SetCondition(int id,Condition condition)
        {
            Conditions[id] = condition;
        }
    }
}