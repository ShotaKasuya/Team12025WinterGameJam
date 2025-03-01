using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Domain.IUseCase.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
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