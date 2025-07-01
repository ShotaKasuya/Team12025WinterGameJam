using Cysharp.Threading.Tasks;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Module.StateMachine;
using Gambit.Unity.Utility.Structure.InGame.StateMachine;

namespace Gambit.Unity.Domain.Flow.InGame
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

        private async UniTask JudgeFlow()
        {
            var result = JudgeCase.Judge();
            
            await JudgeResultPresenter.PresentResult(result);
            
            GameState.ChangeState(GameStateType.AddPoint);
        }

        public GameStateType TargetStateMask => GameStateType.Judge;

        private IJudgeCase JudgeCase { get; }
        private IJudgeResultPresenter JudgeResultPresenter { get; }
        private IMutState<GameStateType> GameState { get; }
    }
}