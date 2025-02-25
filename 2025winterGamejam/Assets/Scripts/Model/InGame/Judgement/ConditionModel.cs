using System.Collections.Generic;
using Domain.IModel.Global;
using Domain.IModel.InGame.Judgement;
using Utility.Structure.InGame;

namespace Model.InGame.Judgement
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