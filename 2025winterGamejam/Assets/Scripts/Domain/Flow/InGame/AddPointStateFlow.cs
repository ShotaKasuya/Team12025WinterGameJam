using System;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Domain.IUseCase.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame;

namespace Domain.Flow.InGame
{
    public class AddPointStateFlow : IStateBehaviour<GameStateType>, IDisposable
    {
        public AddPointStateFlow
        (
            IIsGameEndCase isGameEndCase,
            IAddPointPresenter addPointPresenter,
            IMutState<GameStateType> state
        )
        {
            IsGameEndCase = isGameEndCase;
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
            await AddPointPresenter.AddPoint();

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

        private IDisposable _disposable;
        public GameStateType TargetStateMask { get; } = GameStateType.AddPoint;
        private IIsGameEndCase IsGameEndCase { get; }
        private IAddPointPresenter AddPointPresenter { get; }
        private IMutState<GameStateType> GameState { get; }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}