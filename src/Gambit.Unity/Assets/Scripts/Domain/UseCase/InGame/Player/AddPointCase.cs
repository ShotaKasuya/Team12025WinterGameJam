using System;
using System.Linq;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Utility.Structure.InGame;
using VContainer.Unity;

namespace Gambit.Unity.Domain.UseCase.InGame.Player
{
    public class AddPointCase : IInitializable, IDisposable
    {
        public AddPointCase
        (
            PlayerId playerIdModel,
            IPlayerScoreModel playerScoreModelModel,
            IJudgeEventModel judgeEventModel,
            IPlayerConditionModel playerPlayerConditionModel
        )
        {
            PlayerScoreModel = playerScoreModelModel;
            PlayerIdModel = playerIdModel;
            JudgeEventModel = judgeEventModel;
            PlayerPlayerConditionModel = playerPlayerConditionModel;
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
                if (PlayerIdModel.Equals(winner))
                {
                    int addScoreDebuff = 1;
                    //自身が弱体化しているかの確認
                    if (PlayerPlayerConditionModel.PlayerCondition == Condition.Ten)
                    {
                        addScoreDebuff = 2;
                    }

                    //特殊効果が無効化されているときの処理
                    if (PlayerPlayerConditionModel.PlayerCondition == Condition.Six)
                    {
                        PlayerScoreModel.AddScore(2 * (resultAndDrawCount.DrawCount + 1) / addScoreDebuff);
                    }
                    else
                    {
                        switch (resultAndDrawCount.BattleResult.Cards[PlayerIdModel.Id].Rank)
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
                    if (resultAndDrawCount.BattleResult.Cards[PlayerIdModel.Id].Rank == Rank.Jack)
                    {
                        PlayerScoreModel.AddScore(-4);
                    }
                }
            }
        }

        //7勝利時の相手とのランク差を計算する処理
        private int DefferentRank(ResultAndDrawCount resultAndDrawCount)
        {
            var myRank = resultAndDrawCount.BattleResult.Cards[PlayerIdModel.Id].Rank;

            return (int)myRank -
                   (int)resultAndDrawCount.BattleResult.Cards
                       .Select(x => x.Rank)
                       .Where(x => x != myRank)
                       .Max();
        }

        private IPlayerScoreModel PlayerScoreModel { get; }
        private PlayerId PlayerIdModel { get; }
        private IJudgeEventModel JudgeEventModel { get; }
        private IPlayerConditionModel PlayerPlayerConditionModel { get; }

        public void Dispose()
        {
            JudgeEventModel.JudgeEndEvent -= AddPoint;
        }
    }
}