using System;
using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Controller.InGame
{
    public class ScoreController : IInitializable, IDisposable
    {
        public ScoreController
        (
            IScoreEventModel scoreEventModel,
            IScoreView scoreView
        )
        {
            ScoreEventModel = scoreEventModel;
            ScoreView = scoreView;
        }

        public void Initialize()
        {
            ScoreEventModel.OnScoreChange += ChangeScore;
        }

        private void ChangeScore(IScoreEventModel.Context context)
        {
            ScoreView.SetScore(context.PlayerIndex, context.CurrentScore);
        }

        private IScoreEventModel ScoreEventModel { get; }
        private IScoreView ScoreView { get; }

        public void Dispose()
        {
            ScoreEventModel.OnScoreChange -= ChangeScore;
        }
    }
}