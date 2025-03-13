using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Structure.Utility.InGame.StateMachine;
using R3;
using UnityEngine;

namespace Gambit.Unity.Adapter.Model.InGame
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