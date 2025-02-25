using Domain.IModel.InGame.Judgement;
using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerConditionModel: IMutPlayerConditionModel
    {
        public PlayerConditionModel
        (
            PlayerId playerIdModel,
            IMutConditionModel conditionModel
        )
        {
            PlayerIdModel = playerIdModel;
            ConditionModel = conditionModel;
        }
        
        public void SetCondition(Condition condition)
        {
            ConditionModel.SetCondition(PlayerIdModel.Id, condition);
        }
        public Condition PlayerCondition => ConditionModel.ConditionReader[PlayerIdModel.Id];
        
        private PlayerId PlayerIdModel { get; }
        private IMutConditionModel ConditionModel { get; }
    }
}