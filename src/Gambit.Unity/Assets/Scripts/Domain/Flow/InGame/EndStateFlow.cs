using Gambit.Unity.Structure.Utility.InGame.StateMachine;
using Utility.Module.StateMachine;

namespace Gambit.Unity.Domain.Flow.InGame
{
    public class EndStateFlow: IStateBehaviour<GameStateType>
    {
        public EndStateFlow
        (
        )
        {
            
        }
        
        public void OnEnter(GameStateType prev)
        {
            
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