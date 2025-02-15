using System.Collections.Generic;
using Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface IPlayerConditionModel
    {
        public List<PlayerCondition> PlayerConditions { get; }
    }
}