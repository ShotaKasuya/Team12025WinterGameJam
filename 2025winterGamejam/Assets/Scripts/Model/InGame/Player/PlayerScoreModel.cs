using System.Collections.Generic;
using Domain.IModel.InGame.Player;
using Domain.IModel.InGame;

namespace Model.InGame.Player
{
    public class PlayerScoreModel: IPlayerScoreModel
    {
        public PlayerScoreModel(IPlayerIdModel playerIdModel,IScoreModel scoreModel)
        {
            PlayerIdModel = playerIdModel;
            ScoreModel = scoreModel;
        }

        private IPlayerIdModel PlayerIdModel {get;}
        private IScoreModel ScoreModel{get;}  
        public void AddScore(int score)
        {
            ScoreModel.AddScore(PlayerIdModel.PlayerId.Id,score);
        }
    }
}