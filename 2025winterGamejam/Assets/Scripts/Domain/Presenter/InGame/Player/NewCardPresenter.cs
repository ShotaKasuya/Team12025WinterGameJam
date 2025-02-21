using System;
using Domain.IModel.InGame.Player;
using Domain.IView.InGame;
using Utility.Structure.InGame;

namespace Domain.Presenter.InGame.Player
{
    /// <summary>
    /// 手札の変化を画面に反映する
    /// </summary>
    public class NewCardPresenter : IDisposable
    {
        public NewCardPresenter
        (
            ICardFactory cardFactory,
            IHandCardModel handCardModel,
            ICardPositionsView cardPositionsView
        )
        {
            CardFactory = cardFactory;
            HandCardModel = handCardModel;
            CardPositionsView = cardPositionsView;

            handCardModel.OnAddHandCards += CreateCardView;
        }

        private void CreateCardView(Card card)
        {
            CardFactory.CreateCardView(card);

            FixPosition();
        }

        private void FixPosition()
        {
            var positions = CardPositionsView.CardPositions;
            var cards = CardFactory.Products;
            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];
                var position = positions[i];

                card.ModelTransform.position = position.position;
            }
        }

        private ICardFactory CardFactory { get; }
        private ICardPositionsView CardPositionsView { get; }
        private IHandCardModel HandCardModel { get; }
        
        public void Dispose()
        {
            HandCardModel.OnAddHandCards -= CreateCardView;
        }
    }
}