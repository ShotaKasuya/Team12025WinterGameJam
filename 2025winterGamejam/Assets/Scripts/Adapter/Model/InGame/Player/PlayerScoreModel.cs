using Adapter.IModel.InGame;
using Adapter.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame.Player
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