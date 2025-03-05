using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.IUseCase.InGame
{
    public interface IDrawCase
    {
        public Card[] DrawCard();
    }

    public interface IInitHandCardCase
    {
        public HandCard[] InitHand();
    }
}