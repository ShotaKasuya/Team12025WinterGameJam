using Cysharp.Threading.Tasks;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Module.StateMachine;
using Gambit.Unity.Utility.Structure.InGame;
using Gambit.Unity.Utility.Structure.InGame.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gambit.Unity.Domain.Flow.InGame
{
    public class EndStateFlow : IStateBehaviour<GameStateType>
    {
        public EndStateFlow
        (
            IIsPlayerWinCase isPlayerWinCase,
            IGameEndPresenter gameEndPresenter
        )
        {
            IsPlayerWinCase = isPlayerWinCase;
            GameEndPresenter = gameEndPresenter;
        }

        public IIsPlayerWinCase IsPlayerWinCase { get; }
        public IGameEndPresenter GameEndPresenter { get; }

        public void OnEnter(GameStateType prev)
        {
            var _ = EndFlow();
        }

        private async UniTask EndFlow()
        {
            if (IsPlayerWinCase.IsPlayerWin == Result.Win)
            {
                GameEndPresenter.GameEnd(Result.Win);
            }
            else if (IsPlayerWinCase.IsPlayerWin == Result.Lose)
            {
                GameEndPresenter.GameEnd(Result.Lose);
            }
            else
            {
                GameEndPresenter.GameEnd(Result.Draw);
            }

            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            SceneManager.LoadScene("TitleScene");
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