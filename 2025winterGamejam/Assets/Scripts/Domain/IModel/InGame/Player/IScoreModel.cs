namespace Domain.IModel.InGame.Player
{
    public interface IScoreModelPlayer
    {
        public void AddScore(int score);
    }

    public class MockScoreModelPlayer : IScoreModelPlayer
    {
        public int addscore {get;private set;}

        public void AddScore(int score)
        {
            addscore = score;
        }
    }
}