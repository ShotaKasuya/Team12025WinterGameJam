using System.Collections.Generic;
using Domain.IModel.Global;
using Domain.IModel.InGame;

namespace Model.InGame
{
    public class ScoreModel: IScoreModel
    {
        public ScoreModel(IPlayerCountModel playerCountModel)
        {
            Scores = new List<int>(playerCountModel.PlayerCount);
        }
        
        private List<int> Scores { get; }
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