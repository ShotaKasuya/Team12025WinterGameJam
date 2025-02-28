namespace Adapter.IModel.InGame.Player
{
    public interface IPlayerScoreModel
    {
        public void AddScore(int score);
    }

    public class MockPlayerScoreModel : IPlayerScoreModel
    {
        public int Addscore {get;private set;}

        public void AddScore(int score)
        {
            Addscore = score;
        }
    }
}