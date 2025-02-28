using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;

namespace Domain.Presenter.InGame
{
    /// <summary>
    /// ゲーム開始演出
    /// </summary>
    public class GameStartPresenter: IGameStartPresenter
    {
        public UniTask GameStart()
        {
            return UniTask.CompletedTask;
        }
    }
}