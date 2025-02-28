using System.Threading;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Domain.IUseCase.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
{
    public class JudgeStateFlowCase : IStateBehaviour<GameStateType>
    {
        public JudgeStateFlowCase
        (
            IJudgeCase judgeCase,
            IJudgeResultPresenter judgeResultPresenter,
            IMutState<GameStateType> gameState
        )
        {
            JudgeCase = judgeCase;
            JudgeResultPresenter = judgeResultPresenter;
            GameState = gameState;
        }

        public void OnEnter(GameStateType prev)
        {
            var _ = JudgeFlow();
        }

        public void OnExit(GameStateType next)
        {
        }

        public void StateUpdate(float deltaTime)
        {
        }

        private async UniTask JudgeFlow(CancellationToken cancellation = new CancellationToken())
        {
            var result = JudgeCase.Judge();
            
            await JudgeResultPresenter.PresentResult(result);
            
            GameState.ChangeState(GameStateType.AddPoint);
        }

        public GameStateType TargetStateMask { get; } = GameStateType.Judge;

        private IJudgeCase JudgeCase { get; }
        private IJudgeResultPresenter JudgeResultPresenter { get; }
        private IMutState<GameStateType> GameState { get; }
    }
}