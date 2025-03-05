using System;

namespace Gambit.Unity.Module.Utility.Module.StateMachine
{
    public interface IState<TState> where TState : struct, Enum
    {
        /// <summary>
        /// 現在のステート
        /// </summary>
        public TState State { get; }
        /// <summary>
        /// そのステートであるなら`true`
        /// </summary>
        public bool IsInState(TState state);
        
        public Action<StatePair<TState>> OnStateChange { get; set; }
    }

    public struct StatePair<TState> where TState: struct, Enum
    {
        public StatePair(TState prev, TState next)
        {
            PrevState = prev;
            NextState = next;
        }
        
        public TState PrevState { get; }
        public TState NextState { get; }
    }

    public interface IMutState<TState> : IState<TState> where TState : struct, Enum
    {
        /// <summary>
        /// ステートを変化させる
        /// </summary>
        /// <param name="next">次のステート</param>
        public void ChangeState(TState next);
    }
    public abstract class AbstractState<TState>:IMutState<TState> where TState : struct, Enum
    {
        public TState State { get; private set; }
        public abstract bool IsInState(TState state);
        public Action<StatePair<TState>> OnStateChange { get; set; }

        public void ChangeState(TState next)
        {
            OnStateChange?.Invoke(new StatePair<TState>(State, next));
            State = next;
        }
    }
}