using System;
using System.Collections.Generic;

namespace Utility.Module.StateMachine
{
    public abstract class AbstractStateMachine<TState> where TState: struct, Enum
    {
        protected AbstractStateMachine(IMutState<TState> state, IReadOnlyList<IStateBehaviour<TState>> behaviourEntities)
        {
            State = state;
            StateBehaviourEntities = behaviourEntities;
        }
        
        public void Tick(float deltaTime)
        {
            var currentState = State.State;
            for (int i = 0; i < StateBehaviourEntities.Count; i++)
            {
                var behaviour = StateBehaviourEntities[i];

                if (IsEqual(behaviour.TargetStateMask, currentState))
                {
                    behaviour.StateUpdate(deltaTime);
                }
            }
        }

        public virtual void ChangeState(TState newState)
        {
            CallOnExit(newState);
            CallOnEnter(State.State);
            State.ChangeState(newState);
        }

        private static bool IsEqual(TState lhs, TState rhs)
        {
            return Convert.ToInt32(lhs) == Convert.ToInt32(rhs);
        }
        
        private IMutState<TState> State { get; }
        private IReadOnlyList<IStateBehaviour<TState>> StateBehaviourEntities { get; }

        private void CallOnEnter(TState prev)
        {
            for (int i = 0; i < StateBehaviourEntities.Count; i++)
            {
                var behaviour = StateBehaviourEntities[i];
                if (IsEqual(behaviour.TargetStateMask, prev))
                {
                    behaviour.OnEnter(prev);
                }
            }
        }
        private void CallOnExit(TState next)
        {
            for (int i = 0; i < StateBehaviourEntities.Count; i++)
            {
                var behaviour = StateBehaviourEntities[i];
                if (IsEqual(behaviour.TargetStateMask, next))
                {
                    behaviour.OnExit(next);
                }
            }
        }
    }
}