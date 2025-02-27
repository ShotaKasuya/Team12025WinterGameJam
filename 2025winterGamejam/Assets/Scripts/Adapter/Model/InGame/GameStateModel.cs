using Adapter.IModel.InGame;
using R3;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame
{
    public class GameStateModel: IMutGameStateModel
    {
        public GameStateModel()
        {
            GameStateType = new ReactiveProperty<GameStateType>();
        }
        public void SetGameState(GameStateType gameState)
        {
            Debug.Log($"state change: {gameState}");
            GameStateType.Value = gameState;
        }
        
        private ReactiveProperty<GameStateType> GameStateType { get; }
        public ReadOnlyReactiveProperty<GameStateType> GameState => GameStateType;
        
    }
}