using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Domain.Presenter.InGame
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