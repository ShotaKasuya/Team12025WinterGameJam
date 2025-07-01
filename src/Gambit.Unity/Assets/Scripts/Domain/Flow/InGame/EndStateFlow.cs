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
    public class EndStateFlow : StateBehaviour<GameStateType>
    {
        public EndStateFlow
        (
            IIsPlayerWinCase isPlayerWinCase,
            IGameEndPresenter gameEndPresenter,
            IMutState<GameStateType> gameState
        ) : base(GameStateType.End, gameState)
        {
            IsPlayerWinCase = isPlayerWinCase;
            GameEndPresenter = gameEndPresenter;
        }

        private IIsPlayerWinCase IsPlayerWinCase { get; }
        private IGameEndPresenter GameEndPresenter { get; }

        public override void OnEnter(GameStateType prev)
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
    }
}