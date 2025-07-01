using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IView.InGame.Ui
{
    public interface IScoreView
    {
        public void SetScore(PlayerId playerId, int score);
    }
}