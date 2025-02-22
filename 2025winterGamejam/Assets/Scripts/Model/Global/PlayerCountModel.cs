using Domain.IModel.Global;

namespace Model.Global
{
    public class PlayerCountModel: IMutPlayerCountModel
    {
        public PlayerCountModel()
        {
            PlayerCount = 4;
        }
        public int PlayerCount { get; private set; }
        public void SetPlayerCount(int playerCount)
        {
            PlayerCount = playerCount;
        }
    }
}