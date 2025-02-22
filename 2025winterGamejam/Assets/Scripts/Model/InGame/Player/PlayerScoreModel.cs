using Domain.IModel.InGame.Player;

namespace Model.InGame.Player
{
    public class PlayerScoreModel: IPlayerScoreModel
    {
        public int Score { get; private set; }
        public void AddScore(int score)
        {
            Score += score;
        }
    }
}