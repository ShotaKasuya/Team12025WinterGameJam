using Cysharp.Threading.Tasks;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Structure.Utility.InGame.StateMachine;
using Utility.Module.StateMachine;

namespace Gambit.Unity.Domain.Flow.InGame
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