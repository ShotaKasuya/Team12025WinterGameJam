using System;
using System.Collections.Generic;

namespace Utility.Module.StateMachine
{
    public abstract class AbstractStateMachine<TState>: IDisposable where TState: struct, Enum
    {
        protected AbstractStateMachine(IState<TState> state, List<IStateBehaviour<TState>> behaviourEntities)
        {
            State = state;
            StateBehaviourEntities = behaviourEntities;

            State.OnChangeState += OnChangeState;
            CallOnEnter(default);
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

        private void OnChangeState(StatePair<TState> statePair)
        {
            CallOnExit(statePair.NextState);
            CallOnEnter(statePair.PrevState);
        }

        private static bool IsEqual(TState lhs, TState rhs)
        {
            return Convert.ToInt32(lhs) == Convert.ToInt32(rhs);
        }
        
        private IState<TState> State { get; }
        private List<IStateBehaviour<TState>> StateBehaviourEntities { get; }

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

        public void Dispose()
        {
            State.OnChangeState -= OnChangeState;
        }
    }
}