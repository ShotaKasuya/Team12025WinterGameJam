using System;

namespace Gambit.Unity.Module.Utility.Module.StateMachine
{
    /// <summary>
    /// ステートの振る舞いを行うインターフェース
    /// </summary>
    /// <typeparam name="TState">ステートを示す型</typeparam>
    public interface IStateBehaviour<TState> where TState: struct, Enum
    {
        /// <summary>
        /// 実際に動作を行うステート
        /// </summary>
        public TState TargetStateMask { get; }

        /// <summary>
        /// 動作を行うステートに入った際に呼ばれる
        /// </summary>
        /// <param name="prev">前のステート</param>
        public void OnEnter(TState prev);

        /// <summary>
        /// ステートを出る際に呼ばれる
        /// </summary>
        /// <param name="next">次のステート</param>
        public void OnExit(TState next);

        /// <summary>
        /// `TargetState`の場合にまフレーム呼ばれる
        /// </summary>
        /// <param name="deltaTime">Time.deltaTime</param>
        public void StateUpdate(float deltaTime);
    }

    public abstract class StateBehaviour<TState>: IStateBehaviour<TState> where TState: struct , Enum
    {
        protected StateBehaviour(TState state, IMutState<TState> stateEntity)
        {
            TargetStateMask = state;
            StateEntity = stateEntity;
        }
        public TState TargetStateMask { get; }
        protected IMutState<TState> StateEntity { get; }
        
        public virtual void OnEnter(TState prev)
        {
        }

        public virtual void OnExit(TState next)
        {
        }

        public virtual void StateUpdate(float deltaTime)
        {
        }
    }
}