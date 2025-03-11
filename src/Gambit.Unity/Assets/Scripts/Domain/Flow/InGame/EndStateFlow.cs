using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Domain.IUseCase.InGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility.Module.StateMachine;
using Utility.Structure.InGame;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
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