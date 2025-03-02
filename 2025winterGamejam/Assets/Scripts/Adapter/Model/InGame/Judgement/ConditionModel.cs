using System.Collections.Generic;
using Adapter.IModel.Global;
using Adapter.IModel.InGame.Judgement;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame.Judgement
{
    public class ConditionModel : IMutConditionModel
    {
        public ConditionModel(IPlayerCountModel playerCountModel)
        {
            Conditions = new Condition[playerCountModel.PlayerCount];
        }

        public void SetCondition(int playerId, Condition condition)
        {
            Conditions[playerId] = condition;
        }

        private Condition[] Conditions { get; }
        public IReadOnlyList<Condition> ConditionReader => Conditions;
    }
}