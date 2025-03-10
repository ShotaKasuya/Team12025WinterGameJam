using Gambit.Unity.Module.Utility.Module.StateMachine;
using Gambit.Unity.Structure.Utility.InGame.StateMachine;
using Cysharp.Threading.Tasks;
using Gambit.Unity.Domain.IUseCase.InGame;

namespace Gambit.Unity.Domain.Flow.InGame
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