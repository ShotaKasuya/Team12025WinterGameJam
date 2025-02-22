using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerConditionModel: IMutPlayerConditionModel
    {
        public PlayerConditionModel
        (
            IPlayerIdModel playerIdModel,
            IConditionModel conditionModel
        )
        {
            PlayerIdModel = playerIdModel;
            ConditionModel = conditionModel;
        }
        
        public void SetCondition(Condition condition)
        {
            ConditionModel.SetCondition(PlayerIdModel.PlayerId.Id, condition);
        }
        public Condition PlayerCondition => ConditionModel.ConditionReader[PlayerIdModel.PlayerId.Id];
        
        private IPlayerIdModel PlayerIdModel { get; }
        private IConditionModel ConditionModel { get; }
    }
}