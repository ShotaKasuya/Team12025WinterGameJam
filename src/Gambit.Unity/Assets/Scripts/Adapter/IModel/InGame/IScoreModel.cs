
namespace Gambit.Unity.Adapter.IModel.InGame
using System.Collections.Generic;

{
    public interface IScoreModel
    {
        public int GetScore(int playerId);
        public void AddScore(int playerId, int score);

        public IReadOnlyList<int> GetPlayerScore { get; }

    }
}