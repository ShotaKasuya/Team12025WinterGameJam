using System.Linq;
using Adapter.IModel.Global;
using Adapter.IModel.InGame;
using Adapter.IModel.InGame.Player;
using Domain.IUseCase.InGame;

namespace Domain.UseCase.InGame
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