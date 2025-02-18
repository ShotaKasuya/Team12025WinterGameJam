using System;
using Domain.IModel.InGame;
using Utility.Structure.InGame;

namespace Model.InGame
{
    public class GameStateModel: IMutGameStateModel, IGameStartEventModel, IDrawCardEventModel
    {
        public void SetGameState(GameStateType gameState)
        {
            switch (gameState)
            {
                case GameStateType.Start:
                {
                    GameStartEvent?.Invoke();
                    break;
                }
                case GameStateType.DecisionCard:
                {
                    break;
                }
                case GameStateType.Judge:
                {
                    break;
                }
                case GameStateType.AddPoint:
                {
                    break;
                }
                case GameStateType.DrawCard:
                {
                    GameDrawCardEvent?.Invoke();
                    break;
                }
                case GameStateType.End:
                {
                    break;
                }
            }
        }
        
        public Action GameStartEvent { get; set; }
        public Action GameDrawCardEvent { get; set; }
        
        private GameStateType _gameStateType;
    }
}