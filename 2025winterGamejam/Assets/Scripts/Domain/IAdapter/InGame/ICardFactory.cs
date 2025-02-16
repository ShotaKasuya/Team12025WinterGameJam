using Structure.InGame;

namespace Domain.IAdapter.InGame
{
    public interface ICardFactory
    {
        public void BuildCard(PlayerHandCard playerHandCard);
    }
}