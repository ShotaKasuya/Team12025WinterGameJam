
namespace Domain.IModel.InGame
{
    public interface IScoreModel
    {
        public int GetScore(int playerId);
        public void AddScore(int playerId, int score);
    }
}