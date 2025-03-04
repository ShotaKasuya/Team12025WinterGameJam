using Utility.Structure.InGame;

namespace Domain.IUseCase.InGame
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