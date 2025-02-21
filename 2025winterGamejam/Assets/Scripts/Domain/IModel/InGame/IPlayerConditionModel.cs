using System.Collections.Generic;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface IPlayerConditionModel
    {
        public List<Condition> PlayerConditions { get; }
    }

    public class MockConditionModel: IPlayerConditionModel
    {
        public List<Condition> PlayerConditions { get; } = new List<Condition>(new Condition[4]);

        public void SetCondition(int playerId, Condition condition)
        {
            PlayerConditions[playerId] = condition;
        }
    }
}