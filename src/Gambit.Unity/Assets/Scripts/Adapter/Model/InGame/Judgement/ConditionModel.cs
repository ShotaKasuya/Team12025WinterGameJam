using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.Model.InGame.Judgement
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