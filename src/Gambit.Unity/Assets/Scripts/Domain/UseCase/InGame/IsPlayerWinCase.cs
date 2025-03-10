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

        public IScoreModel ScoreModel { get; }
        public IPlayerIdModel PlayerIdModel { get; }

        public bool IsPlayerWin
        {
            get { return (ScoreModel.GetScore(PlayerIdModel.PlayerId.Id) == ScoreModel.GetPlayerScore.Max()); }
        }
    }
}