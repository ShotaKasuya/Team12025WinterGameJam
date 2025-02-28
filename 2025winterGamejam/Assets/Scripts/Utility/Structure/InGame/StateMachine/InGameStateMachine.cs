using System.Collections.Generic;
using UnityEngine;
using Utility.Module.StateMachine;
using VContainer.Unity;

namespace Utility.Structure.InGame.StateMachine
{
    public class InGameStateMachine : AbstractStateMachine<GameStateType>, IInitializable, ITickable
    {
        public InGameStateMachine
        (
            IMutState<GameStateType> state,
            IReadOnlyList<IStateBehaviour<GameStateType>> behaviourEntities
        ) : base(state, behaviourEntities)
        {
        }

        public void Initialize()
        {
            ChangeState(GameStateType.Init);
        }

        public override void ChangeState(GameStateType newState)
        {
            Debug.Log($"on state change: {newState}");
            base.ChangeState(newState);
        }

        public void Tick()
        {
            base.Tick(Time.deltaTime);
        }
    }
    
    public class GameState: IMutState<GameStateType>
    {
        public GameStateType State { get; private set; } = GameStateType.None;
        
        public bool IsInState(GameStateType state)
        {
            return State == state;
        }

        public void ChangeState(GameStateType next)
        {
            State = next;
        }
    }
}