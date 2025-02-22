using System.Collections.Generic;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface IConditionModel
    {
        public void SetCondition(int playerId, Condition condition);
        public IReadOnlyList<Condition> ConditionReader { get; }
    }
}