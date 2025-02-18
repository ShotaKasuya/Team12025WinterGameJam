namespace Domain.IModel.InGame.Player
{
    public interface IScoreModelPlayer
    {
        public int GetScore();
        public void AddScore(int score);
    }
}