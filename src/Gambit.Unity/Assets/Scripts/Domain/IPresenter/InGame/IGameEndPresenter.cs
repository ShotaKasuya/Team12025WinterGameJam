using Cysharp.Threading.Tasks;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Domain.IPresenter.InGame
{
    public interface IGameEndPresenter
    {
        public UniTask GameEnd(Result result);
    }
}