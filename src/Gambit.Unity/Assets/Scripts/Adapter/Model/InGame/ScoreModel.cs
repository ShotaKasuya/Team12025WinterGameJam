using System;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame;
using System.Collections.Generic;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.Model.InGame
{
    public class ScoreModel: IScoreModel, IScoreEventModel
    {
        public ScoreModel(IPlayerCountModel playerCountModel)
        {
            Scores = new int[playerCountModel.PlayerCount];
        }
        
        private int[] Scores { get; }

        public int GetScore(PlayerId playerId)
        {
            return Scores[playerId.Id];
        }

        public void AddScore(PlayerId playerId, int score)
        {
            var addedScore = Scores[playerId.Id] + score;
            Scores[playerId.Id] = addedScore;
            OnScoreChange?.Invoke(new IScoreEventModel.Context(playerId, addedScore));
        }

        public IReadOnlyList<int> GetPlayerScore => Scores;

        public Action<IScoreEventModel.Context> OnScoreChange { get; set; }
    }
}