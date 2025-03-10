using System.Linq;
using Domain.IUseCase.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Player;

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