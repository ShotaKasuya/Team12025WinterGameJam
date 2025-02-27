using Utility.Structure.InGame;

namespace Domain.IView.InGame
{
    public interface IHandCardInstanceView
    {
        public ProductCardView GetInstance(Card card);
    }
}