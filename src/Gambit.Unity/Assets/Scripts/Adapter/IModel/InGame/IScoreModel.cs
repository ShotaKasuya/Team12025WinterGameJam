
namespace Gambit.Unity.Adapter.IModel.InGame
{
    public interface IScoreModel
    {
        public int GetScore(int playerId);
        public void AddScore(int playerId, int score);
    }
    public class MockScoreModel : IScoreModel
    {
        public int[] Scores {get;private set;}
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
        public void AddScore(int id,int score)
        {
            Scores[id] = score;
        }
    }
}