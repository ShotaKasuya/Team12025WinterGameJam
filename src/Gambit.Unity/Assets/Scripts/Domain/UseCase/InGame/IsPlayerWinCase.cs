using System.Linq;
using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Domain.IUseCase.InGame;

namespace Gambit.Unity.Domain.UseCase.InGame
{
    public class IsPlayerWinCase : IIsPlayerWinCase
    {
        public IsPlayerWinCase
        (
            IScoreModel scoreModel,
            IPlayerIdModel playerIdModel
        )
        {
            ScoreModel = scoreModel;
            PlayerIdModel = playerIdModel;
        }

        private IScoreModel ScoreModel { get; }
        private IPlayerIdModel PlayerIdModel { get; }

        public bool IsPlayerWin
        {
            get { return (ScoreModel.GetScore(PlayerIdModel.PlayerIndex) == ScoreModel.GetPlayerScore.Max()); }
        }
    }
}