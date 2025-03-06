using Cysharp.Threading.Tasks;
using Domain.IUseCase.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
{
    public class EndStateFlow: IStateBehaviour<GameStateType>
    {
        public EndStateFlow
        (
            IIsPlayerWinCase isPlayerWinCase
        )
        {
            IsPlayerWinCase = isPlayerWinCase;
        }
        
        public IIsPlayerWinCase IsPlayerWinCase{ get; }
        
        public void OnEnter(GameStateType prev)
        {
            var _ = EndFlow();
        }

        private async UniTask EndFlow()
        {
            if (IsPlayerWinCase.IsPlayerWin)
            {
                
            }
        }

        public void OnExit(GameStateType next)
        {
        }

        public void StateUpdate(float deltaTime)
        {
        }

        public GameStateType TargetStateMask { get; } = GameStateType.End;
    }
}