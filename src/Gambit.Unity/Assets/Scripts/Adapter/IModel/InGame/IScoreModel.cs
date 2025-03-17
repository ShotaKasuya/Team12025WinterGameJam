using System;
using System.Collections.Generic;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame
{
    public interface IScoreModel
    {
        public int GetScore(int playerId);
        public void AddScore(int playerId, int score);

        public IReadOnlyList<int> GetPlayerScore { get; }
    }

    public interface IScoreEventModel
    {
        public Action<Context> OnScoreChange { get; set; }
        
        public readonly struct Context
        {
            public int PlayerIndex { get; }
            public int CurrentScore { get; }

            public Context(int playerIndex, int currentScore)
            {
                PlayerIndex = playerIndex;
                CurrentScore = currentScore;
            }
        }
    }

    public class MockScoreModel : IScoreModel
    {
        public int[] Scores { get; private set; }

        public MockScoreModel
        (
            int playerCount
        )
        {
            Scores = new int[playerCount];
        }

        public int GetScore(int id)
        {
            return Scores[id];
        }

        public void AddScore(int id, int score)
        {
            Scores[id] = score;
        }

        public IReadOnlyList<int> GetPlayerScore => Scores;
    }
}