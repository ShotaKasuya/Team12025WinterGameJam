using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Domain.IUseCase.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
{
    public class DrawCardStateFlow: IStateBehaviour<GameStateType>
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
            await DrawPresenter.PresentDraw(cards);
            
            GameState.ChangeState(GameStateType.DecisionCard);
        }

        public GameStateType TargetStateMask { get; } = GameStateType.DrawCard;
        
        private IDrawCase DrawCase { get; }
        private IDrawPresenter DrawPresenter { get; }
        private IMutState<GameStateType> GameState { get; }
    }
}