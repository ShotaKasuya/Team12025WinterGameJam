using System;
using Domain.IModel.InGame;
using R3;
using Utility.Structure.InGame;

namespace Model.InGame
{
    public class GameStateModel: IMutGameStateModel, IGameStartEventModel, IDrawCardEventModel
    {
        public GameStateModel()
        {
            GameStateType = new ReactiveProperty<GameStateType>();
        }
        public void SetGameState(GameStateType gameState)
        {
            GameStateType.Value = gameState;
        }
        
        private ReactiveProperty<GameStateType> GameStateType { get; }
        public ReadOnlyReactiveProperty<GameStateType> GameState => GameStateType;
        public Action GameStartEvent { get; set; }
        public Action GameDrawCardEvent { get; set; }
        
    }
}