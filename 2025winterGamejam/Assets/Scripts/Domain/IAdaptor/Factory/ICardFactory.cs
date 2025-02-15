using Domain.IView.InGame;
using Structure.InGame;

namespace Domain.IAdaptor.Factory
{
    public interface ICardFactory
    {
        public FactorableCardView BuildCard(PlayerHandCard playerHandCard);
    }
}