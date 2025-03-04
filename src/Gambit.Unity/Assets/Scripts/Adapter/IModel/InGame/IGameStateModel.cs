using R3;
using Utility.Structure.InGame;
using Utility.Structure.InGame.StateMachine;

namespace Adapter.IModel.InGame
{
    public interface IMutGameStateModel: IGameStateModel
    {
        public void SetGameState(GameStateType gameState);
    }

    public interface IGameStateModel
    {
        public ReadOnlyReactiveProperty<GameStateType> GameState { get; }
    }

    public class MockStateEventModel : IMutGameStateModel
    {
        public void InvokeGameStart()
        {
            SetGameState(GameStateType.Init);
        }

        public void InvokeDrawCard()
        {
            SetGameState(GameStateType.DrawCard);
        }

        private ReactiveProperty<GameStateType> State { get; } = new ReactiveProperty<GameStateType>();
        public ReadOnlyReactiveProperty<GameStateType> GameState => State;
        public void SetGameState(GameStateType gameState)
        {
            State.Value = gameState;
        }
    }
}