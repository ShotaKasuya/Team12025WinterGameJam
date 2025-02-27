using System;

namespace Utility.Module.StateMachine
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
        /// <summary>
        /// ステートが変化した際のイベント
        /// </summary>
        public Action<StatePair<TState>> OnChangeState { get; set; }
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
}