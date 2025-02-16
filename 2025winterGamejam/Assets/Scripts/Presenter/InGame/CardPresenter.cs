using System.Collections.Generic;
using Domain.IPresenter.InGame;
using IView.InGame;

namespace Presenter.InGame
{
    public class CardPresenter : ICardReceivable
    {
        public CardPresenter
        (
            ICardPositionView cardPositionView
        )
        {
            CardPositionView = cardPositionView;
        }

        public void ReceiveCard(ICardView cardView)
        {
            CardViews.Add(cardView);
            FixPosition();
        }

        public void ReleaseCard(ICardView cardView)
        {
            CardViews.Remove(cardView);
            FixPosition();
        }

        private void FixPosition()
        {
            for (int i = 0; i < CardViews.Count; i++)
            {
                var view = CardViews[i];
                var point = CardPositionView.CardPositions[i];

                view.ModelTransform.position = point.position;
            }
        }

        private List<ICardView> CardViews { get; } = new List<ICardView>();
        private ICardPositionView CardPositionView { get; }
    }
}