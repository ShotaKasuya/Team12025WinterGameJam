using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerConditionModel: IMutConditionModel
    {
        public void SetCondition(Condition condition)
        {
            Condition = condition;
        }
        public Condition Condition { get; private set; }
    }
}