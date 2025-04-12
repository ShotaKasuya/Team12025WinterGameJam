using System.Linq;
using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Structure.InGame;

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

        public Result IsPlayerWin
        {
            get
            {
                var score = ScoreModel.GetScore(PlayerIdModel.LocalPlayerId);
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