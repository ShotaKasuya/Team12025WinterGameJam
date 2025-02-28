using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Domain.IUseCase.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
{
    public class DecisionCardStateFlow : IStateBehaviour<GameStateType>
    {
        public DecisionCardStateFlow
        (
            IIsReadyJudgeCase isReadyJudgeCase,
            IDecisionPresenter decisionPresenter,
            IMutState<GameStateType> gameState
        )
        {
            IsReadyJudgeCase = isReadyJudgeCase;
            DecisionPresenter = decisionPresenter;
            GameState = gameState;
        }

        public void OnEnter(GameStateType prev)
        {
            var _ = DecisionCardFlow();
        }

        public void OnExit(GameStateType next)
        {
        }

        public void StateUpdate(float deltaTime)
        {
        }

        private async UniTask DecisionCardFlow()
        {
            await UniTask.WaitUntil(() => IsReadyJudgeCase.IsReady);
            await DecisionPresenter.PresentDecision();

            GameState.ChangeState(GameStateType.Judge);
        }

        public GameStateType TargetStateMask { get; } = GameStateType.DecisionCard;
        private IIsReadyJudgeCase IsReadyJudgeCase { get; }
        private IDecisionPresenter DecisionPresenter { get; }
        private IMutState<GameStateType> GameState { get; }
    }
}