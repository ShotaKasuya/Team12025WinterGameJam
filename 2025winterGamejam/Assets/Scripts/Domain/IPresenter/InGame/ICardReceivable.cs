using IView.InGame;

namespace Domain.IPresenter.InGame
{
    public interface ICardReceivable
    {
        public void ReceiveCard(ICardView cardView);
        public void ReleaseCard(ICardView cardView);
    }
}