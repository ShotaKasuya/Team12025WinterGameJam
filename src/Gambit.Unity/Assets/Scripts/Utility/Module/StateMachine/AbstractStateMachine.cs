using System;
using System.Collections.Generic;

namespace Gambit.Unity.Module.Utility.Module.StateMachine
{
    public abstract class AbstractStateMachine<TState>: IDisposable where TState: struct, Enum
    {
        protected AbstractStateMachine(IMutState<TState> state, IReadOnlyList<IStateBehaviour<TState>> behaviourEntities)
        {
            State = state;
            StateBehaviourEntities = behaviourEntities;
        }

        protected void Init(TState enter)
        {
            State.OnStateChange += OnChangeState;
            State.ChangeState(enter);
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

        protected virtual void OnChangeState(StatePair<TState> statePair)
        {
            CallOnExit(statePair.PrevState);
            CallOnEnter(statePair.NextState);
        }

        private static bool IsEqual(TState lhs, TState rhs)
        {
            return Convert.ToInt32(lhs) == Convert.ToInt32(rhs);
        }
        
        private IMutState<TState> State { get; }
        private IReadOnlyList<IStateBehaviour<TState>> StateBehaviourEntities { get; }

        private void CallOnEnter(TState next)
        {
            for (int i = 0; i < StateBehaviourEntities.Count; i++)
            {
                var behaviour = StateBehaviourEntities[i];
                if (IsEqual(behaviour.TargetStateMask, next))
                {
                    behaviour.OnEnter(next);
                }
            }
        }
        private void CallOnExit(TState prev)
        {
            for (int i = 0; i < StateBehaviourEntities.Count; i++)
            {
                var behaviour = StateBehaviourEntities[i];
                if (IsEqual(behaviour.TargetStateMask, prev))
                {
                    behaviour.OnExit(prev);
                }
            }
        }

        public void Dispose()
        {
            State.OnStateChange -= OnChangeState;
        }
    }
}