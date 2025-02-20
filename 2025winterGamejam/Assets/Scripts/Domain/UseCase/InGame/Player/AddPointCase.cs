using System;
using System.Linq;
using Codice.Client.Common.GameUI;
using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame.Player
{
    public class AddPointCase : IDisposable
    {
        public AddPointCase
        (
            IScoreModelPlayer scoreModelPlayerModel,
            IPlayerIdModel playerIdModel,
            IJudgeEventModel judgeEventModel,
            IPlayerConditionModel playerConditionModel
        )
        {
            ScoreModelPlayer = scoreModelPlayerModel;
            PlayerIdModel = playerIdModel;
            JudgeEventModel = judgeEventModel;
            PlayerConditionModel = playerConditionModel;

            JudgeEventModel.JudgeEndEvent += AddPoint;
        }

        private void AddPoint(ResultAndDrawCount resultAndDrawCount)
        {
            if (resultAndDrawCount.BattleResult.Winner.TryGetValue(out PlayerId winner))
            {
                if (PlayerIdModel.PlayerId.Equals(winner))
                {
                    int AddScoreDebuff = 1;
                    if(PlayerConditionModel.PlayerConditions[PlayerIdModel.PlayerId.Id]==Condition.Ten)
                    {
                        AddScoreDebuff = 2;
                    }
                    if(PlayerConditionModel.PlayerConditions[PlayerIdModel.PlayerId.Id]==Condition.Six)
                    {
                        ScoreModelPlayer.AddScore(2 * (resultAndDrawCount.DrawCount + 1)/AddScoreDebuff);
                    }
                    else
                    {
                        switch (resultAndDrawCount.BattleResult.Cards[PlayerIdModel.PlayerId.Id].Rank)
                        {
                            case Rank.Seven:
                                ScoreModelPlayer.AddScore(2 * (resultAndDrawCount.DrawCount + 1)*DefferentRank(resultAndDrawCount)/AddScoreDebuff);
                                break;
                            case Rank.Nine:
                                ScoreModelPlayer.AddScore((2 * (resultAndDrawCount.DrawCount + 1) + 2)/AddScoreDebuff);
                                break;
                            case Rank.Jack:
                                ScoreModelPlayer.AddScore((2 * (resultAndDrawCount.DrawCount + 1) + 4)/AddScoreDebuff);
                                break;
                            default:
                                ScoreModelPlayer.AddScore(2 * (resultAndDrawCount.DrawCount + 1)/AddScoreDebuff);
                                break;
                        }
                    }
                }
                else
                {
                    if (resultAndDrawCount.BattleResult.Cards[PlayerIdModel.PlayerId.Id].Rank == Rank.Jack)
                    {
                        ScoreModelPlayer.AddScore(-4);
                    }
                }
            }
        }

        private int DefferentRank(ResultAndDrawCount resultAndDrawCount)
        {
            var myRank = resultAndDrawCount.BattleResult.Cards[PlayerIdModel.PlayerId.Id].Rank;

            return (int)myRank -
                   (int)resultAndDrawCount.BattleResult.Cards
                       .Select(x => x.Rank)
                       .Where(x => x != myRank)
                       .Max();
        }

        private IScoreModelPlayer ScoreModelPlayer { get; }
        private IPlayerIdModel PlayerIdModel { get; }
        private IJudgeEventModel JudgeEventModel { get; }
        private IPlayerConditionModel PlayerConditionModel{ get; }

        public void Dispose()
        {
            JudgeEventModel.JudgeEndEvent -= AddPoint;
        }
    }
}