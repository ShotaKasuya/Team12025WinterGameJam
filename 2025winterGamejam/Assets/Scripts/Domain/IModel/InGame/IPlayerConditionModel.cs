using System.Collections.Generic;
using Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface IPlayerConditionModel
    {
        public List<Condition> PlayerConditions { get; }
    }

    public class MockConditionModel: IPlayerConditionModel
    {
        public List<Condition> PlayerConditions { get; } = new List<Condition>();

        public void SetCondition(int playerId, Condition condition)
        {
            PlayerConditions[playerId] = condition;
        }
    }
}