using System.Collections.Generic;
using Domain.IModel.InGame;
using Utility.Structure.InGame;

namespace Model.InGame
{
    public class PlayerConditionModel: IPlayerConditionModel
    {
        public List<Condition> PlayerConditions { get; }
    }
}