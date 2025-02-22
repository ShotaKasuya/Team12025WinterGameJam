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

    public class MockConditionModel : IMutConditionModel
    {
        public Condition Condition { get; private set; }
        public void SetCondition(Condition condition)
        {
            Condition = condition;
        }
    }
}