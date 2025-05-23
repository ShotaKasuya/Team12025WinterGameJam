using System.Collections.Generic;
using Gambit.Unity.Utility.Module.StateMachine;
using UnityEngine;
using VContainer.Unity;

namespace Gambit.Unity.Utility.Structure.InGame.StateMachine
{
    public class InGameStateMachine : AbstractStateMachine<GameStateType>, IStartable, ITickable
    {
        public InGameStateMachine
        (
            IMutState<GameStateType> state,
            IReadOnlyList<IStateBehaviour<GameStateType>> behaviourEntities
        ) : base(state, behaviourEntities)
        {
        }

        public void Start()
        {
            Init(GameStateType.Init);
        }

        protected override void OnChangeState(StatePair<GameStateType> statePair)
        {
            Debug.Log($"state change: (prev, next) => ({statePair.PrevState}, {statePair.NextState})");
            base.OnChangeState(statePair);
        }

        public void Tick()
        {
            base.Tick(Time.deltaTime);
        }
    }
    
    public class GameState: AbstractState<GameStateType>
    {
        public override bool IsInState(GameStateType state)
        {
            return State == state;
        }
    }
}