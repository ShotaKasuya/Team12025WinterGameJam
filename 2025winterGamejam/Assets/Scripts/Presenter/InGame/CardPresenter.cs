using System.Collections.Generic;
using Domain.IPresenter.InGame;
using IView.InGame;

namespace Presenter.InGame
{
    public class CardPresenter : ICardReceivable
    {
        public CardPresenter
        (
            List<ICardPositionsView> cardPositionsView
        )
        {
            CardPositionsView = cardPositionsView;
        }

        public void ReceiveCard(ICardView cardView)
        {
            var playerId = cardView.Card.PlayerId;
            if (CardViews.Capacity < cardView.Card.PlayerId - 1)
            {
                CardViews.Capacity = playerId;
            }

            CardViews[cardView.Card.PlayerId].Add(cardView);
            FixPosition();
        }

        public void ReleaseCard(ICardView cardView)
        {
            CardViews[cardView.Card.PlayerId].Remove(cardView);
            FixPosition();
        }

        private void FixPosition()
        {
            for (int i = 0; i < CardViews.Count; i++)
            {
                var views = CardViews[i];
                var positions = CardPositionsView[i].CardPositions;
                for (int j = 0; j < views.Count; j++)
                {
                    var view = views[j];
                    var position = positions[j];

                    view.ModelTransform.position = position.position;
                }
            }
            // for (int i = 0; i < CardViews.Count; i++)
            // {
            //     var view = CardViews[i];
            //     var point = CardPositionsView.CardPositions[i];
            //
            //     view.ModelTransform.position = point.position;
            // }
        }

        private List<List<ICardView>> CardViews { get; } = new();
        private List<ICardPositionsView> CardPositionsView { get; }
    }
}