using Cysharp.Threading.Tasks;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Module.StateMachine;
using Gambit.Unity.Utility.Structure.InGame.StateMachine;

namespace Gambit.Unity.Domain.Flow.InGame
{
    public class DrawCardStateFlow : IStateBehaviour<GameStateType>
    {
        public DrawCardStateFlow
        (
            IDrawCase drawCase,
            IDrawPresenter drawPresenter,
            IMutState<GameStateType> gameState
        )
        {
            DrawCase = drawCase;
            DrawPresenter = drawPresenter;
            GameState = gameState;
        }

        public void OnEnter(GameStateType prev)
        {
            var _ = DrawCardFlow();
        }

        public void OnExit(GameStateType next)
        {
        }

        public void StateUpdate(float deltaTime)
        {
        }

        private async UniTask DrawCardFlow()
        {
            var cards = DrawCase.DrawCard();
            if (cards.TryGetValue(out var value))
            {
                await DrawPresenter.PresentDraw(value);
            }

            GameState.ChangeState(GameStateType.DecisionCard);
        }

        public GameStateType TargetStateMask { get; } = GameStateType.DrawCard;

        private IDrawCase DrawCase { get; }
        private IDrawPresenter DrawPresenter { get; }
        private IMutState<GameStateType> GameState { get; }
    }
}