using Adapter.IView.InGame.Ui;
using CodiceApp.Gravatar;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using UnityEngine;
using Utility.Structure.InGame;
using Input = UnityEngine.Windows.Input;

namespace Domain.Presenter.InGame
{
    public class GameEndPresenter : IGameEndPresenter
    {
        public GameEndPresenter
        (
            IGameResultView gameResultView
        )
        {
            GameResultView = gameResultView;
        }
        public IGameResultView GameResultView { get; }
        
        public UniTask GameEnd(Result result)
        {
            GameResultView.Enable(result);

            return UniTask.CompletedTask;
        }
    }
}