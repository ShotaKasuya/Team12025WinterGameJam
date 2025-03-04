using Adapter.IModel.Global;
using Adapter.IModel.InGame;

namespace Adapter.Model.InGame
{
    public class ScoreModel: IScoreModel
    {
        public ScoreModel(IPlayerCountModel playerCountModel)
        {
            Scores = new int[playerCountModel.PlayerCount];
        }
        
        private int[] Scores { get; }
        public int GetScore(int playerId)
        {
            return Scores[playerId];
        }

        public void AddScore(int playerId, int score)
        {
            Scores[playerId] = score;
        }
    }
}