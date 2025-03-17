using Cysharp.Threading.Tasks;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Module.StateMachine;
using Gambit.Unity.Utility.Structure.InGame.StateMachine;

namespace Gambit.Unity.Domain.Flow.InGame
{
    public class DecisionCardStateFlow : StateBehaviour<GameStateType>
    {
        public DecisionCardStateFlow
        (
            IIsReadyJudgeCase isReadyJudgeCase,
            IDecisionPresenter decisionPresenter,
            IMutState<GameStateType> gameState
        ) : base(GameStateType.DecisionCard, gameState)
        {
            IsReadyJudgeCase = isReadyJudgeCase;
            DecisionPresenter = decisionPresenter;
            GameState = gameState;
        }

        public override void OnEnter(GameStateType prev)
        {
            var _ = DecisionCardFlow();
        }

        private async UniTask DecisionCardFlow()
        {
            await UniTask.WaitUntil(() => IsReadyJudgeCase.IsReady);
            var selectedCards = IsReadyJudgeCase.SelectedCards;
            
            await DecisionPresenter.PresentDecision(selectedCards);

            GameState.ChangeState(GameStateType.Judge);
        }

        private IIsReadyJudgeCase IsReadyJudgeCase { get; }
        private IDecisionPresenter DecisionPresenter { get; }
        private IMutState<GameStateType> GameState { get; }
    }
}