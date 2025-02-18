using System;
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
            IJudgeEventModel judgeEventModel
        )
        {
            ScoreModelPlayer = scoreModelPlayerModel;
            PlayerIdModel = playerIdModel;
            JudgeEventModel = judgeEventModel;

            JudgeEventModel.JudgeEndEvent += AddPoint;
        }

        private void AddPoint(BattleResult battleResult)
        {
        }

        private IScoreModelPlayer ScoreModelPlayer { get; }
        private IPlayerIdModel PlayerIdModel { get; }
        private IJudgeEventModel JudgeEventModel { get; }

        public void Dispose()
        {
            JudgeEventModel.JudgeEndEvent -= AddPoint;
        }
    }
}