using System;
using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Controller.InGame
{
    public class ScoreController : IInitializable, IDisposable
    {
        public ScoreController
        (
            IPlayerIdModel playerIdModel,
            IPlayerDictionaryModel playerDictionaryModel,
            IScoreEventModel scoreEventModel,
            IScoreView scoreView
        )
        {
            PlayerIdModel = playerIdModel;
            PlayerDictionaryModel = playerDictionaryModel;
            ScoreEventModel = scoreEventModel;
            ScoreView = scoreView;
        }

        public void Initialize()
        {
            ScoreEventModel.OnScoreChange += ChangeScore;
        }

        private void ChangeScore(IScoreEventModel.Context context)
        {
            var id = PlayerDictionaryModel.PlayerIds[context.PlayerIndex];
            if (id != PlayerIdModel.PlayerId)
            {
                return;
            }

            ScoreView.SetScore(context.CurrentScore);
        }

        private IPlayerIdModel PlayerIdModel { get; }
        private IPlayerDictionaryModel PlayerDictionaryModel { get; }
        private IScoreEventModel ScoreEventModel { get; }
        private IScoreView ScoreView { get; }

        public void Dispose()
        {
            ScoreEventModel.OnScoreChange -= ChangeScore;
        }
    }
}