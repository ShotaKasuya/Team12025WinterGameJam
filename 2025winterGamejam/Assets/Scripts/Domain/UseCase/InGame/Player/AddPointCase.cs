using System;
using System.Linq;
using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame.Player
{
    public class AddPointCase : IInitializable, IDisposable
    {
        public AddPointCase
        (
            IPlayerScoreModel playerScoreModelModel,
            IPlayerIdModel playerIdModel,
            IJudgeEventModel judgeEventModel,
            IConditionModel playerConditionModel
        )
        {
            PlayerScoreModel = playerScoreModelModel;
            PlayerIdModel = playerIdModel;
            JudgeEventModel = judgeEventModel;
            PlayerConditionModel = playerConditionModel;
        }

        public void Initialize()
        {
            JudgeEventModel.JudgeEndEvent += AddPoint;
        }

        //点数計算
        private void AddPoint(ResultAndDrawCount resultAndDrawCount)
        {
            if (resultAndDrawCount.BattleResult.Winner.TryGetValue(out PlayerId winner))
            {
                if (PlayerIdModel.PlayerId.Equals(winner))
                {
                    int addScoreDebuff = 1;
                    //自身が弱体化しているかの確認
                    if (PlayerConditionModel.Condition == Condition.Ten)
                    {
                        addScoreDebuff = 2;
                    }

                    //特殊効果が無効化されているときの処理
                    if (PlayerConditionModel.Condition == Condition.Six)
                    {
                        PlayerScoreModel.AddScore(2 * (resultAndDrawCount.DrawCount + 1) / addScoreDebuff);
                    }
                    else
                    {
                        switch (resultAndDrawCount.BattleResult.Cards[PlayerIdModel.PlayerId.Id].Rank)
                        {
                            case Rank.Seven:
                                PlayerScoreModel.AddScore(2 * (resultAndDrawCount.DrawCount + 1) *
                                    DefferentRank(resultAndDrawCount) / addScoreDebuff);
                                break;
                            case Rank.Nine:
                                PlayerScoreModel.AddScore((2 * (resultAndDrawCount.DrawCount + 1) + 2) /
                                                          addScoreDebuff);
                                break;
                            case Rank.Jack:
                                PlayerScoreModel.AddScore((2 * (resultAndDrawCount.DrawCount + 1) + 4) /
                                                          addScoreDebuff);
                                break;
                            default:
                                PlayerScoreModel.AddScore(2 * (resultAndDrawCount.DrawCount + 1) / addScoreDebuff);
                                break;
                        }
                    }
                }
                else
                {
                    //Jで負けた時の-4される処理
                    if (resultAndDrawCount.BattleResult.Cards[PlayerIdModel.PlayerId.Id].Rank == Rank.Jack)
                    {
                        PlayerScoreModel.AddScore(-4);
                    }
                }
            }
        }

        //7勝利時の相手とのランク差を計算する処理
        private int DefferentRank(ResultAndDrawCount resultAndDrawCount)
        {
            var myRank = resultAndDrawCount.BattleResult.Cards[PlayerIdModel.PlayerId.Id].Rank;

            return (int)myRank -
                   (int)resultAndDrawCount.BattleResult.Cards
                       .Select(x => x.Rank)
                       .Where(x => x != myRank)
                       .Max();
        }

        private IPlayerScoreModel PlayerScoreModel { get; }
        private IPlayerIdModel PlayerIdModel { get; }
        private IJudgeEventModel JudgeEventModel { get; }
        private IConditionModel PlayerConditionModel { get; }

        public void Dispose()
        {
            JudgeEventModel.JudgeEndEvent -= AddPoint;
        }
    }
}