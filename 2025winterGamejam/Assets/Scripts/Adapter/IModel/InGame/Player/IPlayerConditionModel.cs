using Utility.Structure.InGame;

namespace Adapter.IModel.InGame.Player
{
    public interface IMutPlayerConditionModel: IPlayerConditionModel
    {
        public void SetCondition(Condition condition);
    }
    public interface IPlayerConditionModel
    {
        public Condition PlayerCondition { get; }
    }

    public class MockPlayerConditionModel : IMutPlayerConditionModel
    {
        public Condition PlayerCondition { get; private set; }
        public void SetCondition(Condition condition)
        {
            PlayerCondition = condition;
        }
    }
}