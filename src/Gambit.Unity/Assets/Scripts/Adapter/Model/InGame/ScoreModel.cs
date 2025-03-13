using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame;
using System.Collections.Generic;

namespace Gambit.Unity.Adapter.Model.InGame
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

        public IReadOnlyList<int> GetPlayerScore => Scores;
        
    }
}