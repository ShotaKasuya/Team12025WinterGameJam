using Gambit.Unity.Structure.Utility.InGame.StateMachine;
using R3;

namespace Gambit.Unity.Adapter.IModel.InGame
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