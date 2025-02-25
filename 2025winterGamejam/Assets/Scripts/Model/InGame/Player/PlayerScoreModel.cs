using Domain.IModel.InGame.Player;
using Domain.IModel.InGame;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerScoreModel : IPlayerScoreModel
    {
        public PlayerScoreModel(PlayerId playerIdModel, IScoreModel scoreModel)
        {
            PlayerIdModel = playerIdModel;
            ScoreModel = scoreModel;
        }

        private PlayerId PlayerIdModel { get; }
        private IScoreModel ScoreModel { get; }

        public void AddScore(int score)
        {
            ScoreModel.AddScore(PlayerIdModel.Id, score);
        }
    }
}