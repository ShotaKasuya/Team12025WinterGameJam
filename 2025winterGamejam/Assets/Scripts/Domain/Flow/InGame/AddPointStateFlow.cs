using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Domain.IUseCase.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
{
    public class AddPointStateFlow : StateBehaviour<GameStateType>
    {
        public AddPointStateFlow
        (
            IIsGameEndCase isGameEndCase,
            IAddPointCase addPointCase,
            IAddPointPresenter addPointPresenter,
            IMutState<GameStateType> gameState
        ) : base(GameStateType.AddPoint, gameState)
        {
            IsGameEndCase = isGameEndCase;
            AddPointCase = addPointCase;
            AddPointPresenter = addPointPresenter;
        }

        public override void OnEnter(GameStateType prev)
        {
            var _ = AddPointFlow();
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

            StateEntity.ChangeState(transitionTo);
        }

        private IIsGameEndCase IsGameEndCase { get; }
        private IAddPointCase AddPointCase { get; }
        private IAddPointPresenter AddPointPresenter { get; }
    }
}