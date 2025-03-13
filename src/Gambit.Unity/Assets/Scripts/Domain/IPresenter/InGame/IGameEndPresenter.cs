using Cysharp.Threading.Tasks;
using Utility.Structure.InGame;

namespace Domain.IPresenter.InGame
{
    public interface IGameEndPresenter
    {
        public UniTask GameEnd(Result result);
    }
}