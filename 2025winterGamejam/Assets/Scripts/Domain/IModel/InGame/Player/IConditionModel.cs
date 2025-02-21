using Utility.Structure.InGame;

namespace Domain.IModel.InGame.Player
{
    public interface IMutConditionModel: IConditionModel
    {
        public void SetCondition(Condition condition);
    }
    public interface IConditionModel
    {
        public Condition Condition { get; }
    }
}