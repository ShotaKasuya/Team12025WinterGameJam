using Utility.Module.StateMachine;
using Utility.Structure.InGame;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
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