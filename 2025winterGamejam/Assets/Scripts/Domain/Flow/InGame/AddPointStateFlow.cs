using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Domain.IUseCase.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame;

namespace Domain.Flow.InGame
{
    public class AddPointStateFlow : IStateBehaviour<GameStateType>
    {
        public AddPointStateFlow
        (
            IIsGameEndCase isGameEndCase,
            IAddPointCase addPointCase,
            IAddPointPresenter addPointPresenter,
            IMutState<GameStateType> state
        )
        {
            IsGameEndCase = isGameEndCase;
            AddPointCase = addPointCase;
            AddPointPresenter = addPointPresenter;
            GameState = state;
        }

        public void OnEnter(GameStateType prev)
        {
            var _ = AddPointFlow();
        }

        public void OnExit(GameStateType next)
        {
        }

        public void StateUpdate(float deltaTime)
        {
        }

        private async UniTask AddPointFlow()
        {
            var points = AddPointCase.AddPoint();
            await AddPointPresenter.PresentAddPoint(points);

            GameStateType transitionTo;
            if (IsGameEndCase.IsGameEnded)
            {
                transitionTo = GameStateType.End;
            }
            else
            {
                transitionTo = GameStateType.DrawCard;
            }

            GameState.ChangeState(transitionTo);
        }

        public GameStateType TargetStateMask { get; } = GameStateType.AddPoint;
        private IIsGameEndCase IsGameEndCase { get; }
        private IAddPointCase AddPointCase { get; }
        private IAddPointPresenter AddPointPresenter { get; }
        private IMutState<GameStateType> GameState { get; }
    }
}