using Gambit.Unity.Utility.Module.Option;
using Gambit.Unity.Utility.Structure.InGame;

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