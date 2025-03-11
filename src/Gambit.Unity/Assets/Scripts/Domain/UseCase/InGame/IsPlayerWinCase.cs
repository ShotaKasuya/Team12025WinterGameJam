using System.Linq;
using Adapter.IModel.Global;
using Adapter.IModel.InGame;
using Adapter.IModel.InGame.Player;
using CodiceApp.Gravatar;
using Domain.IUseCase.InGame;
using Utility.Structure.InGame;

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

        public Result IsPlayerWin
        {
            get
            {
                var score = ScoreModel.GetScore(PlayerIdModel.PlayerId.Id);
                var max = ScoreModel.GetPlayerScore.Max();
                var maxcount = ScoreModel.GetPlayerScore.Count(x => x == max);

                if (score == max)
                {
                    if (maxcount != 1)
                    {
                        return Result.Draw;
                    }
                    
                    return Result.Win;
                }
                else
                {
                    return Result.Lose;
                }
            }
        }
    }
}