using Gambit.Unity.Module.Utility.Module.Option;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.IUseCase.InGame
{
    public interface IDrawCase
    {
        public Option<PlayerCard[]> DrawCard();
    }

    public interface IInitHandCardCase
    {
        public HandCard[] InitHand();
    }
}