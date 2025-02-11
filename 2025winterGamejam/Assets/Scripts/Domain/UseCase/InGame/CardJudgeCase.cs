using Domain.IModel.InGame;
using Domain.IView.InGame;
using Structure.InGame;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 勝敗をジャッジする
    /// </summary>
    public class CardJudgeCase
    {
        public CardJudgeCase
        (
            IPlayerDecision playerDecision,
            IScoreModel scoreModel,
            IMatchScoreModel matchScoreModel
        )
        {
            playerDecision.CardDecisionEvent += OnDecision;

            PlayerDecision = playerDecision;
            ScoreModel = scoreModel;
            MatchScoreModel = matchScoreModel;
        }

        private void OnDecision((Card, Card) playerCard)
        {
            var result = Judge();

            if (result != -1)
            {
                ScoreModel.AddScore(result, MatchScoreModel.WinnerScore);
            }
            // todo: 引き分け
        }

        private enum Result
        {
            Win,
            Draw,
            Lose,
        }

        private int Judge()
        {
            // todo: 勝敗
            return -1;
        }

        private IPlayerDecision PlayerDecision { get; }
        private IScoreModel ScoreModel { get; }
        private IMatchScoreModel MatchScoreModel { get; }
    }
}