using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame;

namespace Domain.Flow.InGame
{
    /// <summary>
    /// 最初のステート
    /// </summary>
    public class InitStateFlow: IStateBehaviour<GameStateType>
    {
        public InitStateFlow
        (
            IGameStartPresenter gameStartPresenter, 
            IMutState<GameStateType> gameState
            )
        {
            GameStartPresenter = gameStartPresenter;
            GameState = gameState;
        }

        public void OnEnter(GameStateType prev)
        {
            var _ = StartFlow();
        }

        public void OnExit(GameStateType next)
        {
        }

        public void StateUpdate(float deltaTime)
        {
        }

        private async UniTask StartFlow()
        {
            await GameStartPresenter.GameStart();
            GameState.ChangeState(GameStateType.DecisionCard);
        }

        public GameStateType TargetStateMask { get; } = GameStateType.Init;
        
        private IGameStartPresenter GameStartPresenter { get; }
        private IMutState<GameStateType> GameState { get; }
    }
}