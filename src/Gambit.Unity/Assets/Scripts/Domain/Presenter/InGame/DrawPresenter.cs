using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Utility.Structure.InGame;

namespace Domain.Presenter.InGame
{
    /// <summary>
    /// デッキからカードを引く演出
    /// </summary>
    public class DrawPresenter : IDrawPresenter, IInitHandPresenter
    {
        public DrawPresenter
        (
            ICardFactory cardFactory,
            IHandCardPoolView handCardPoolView
        )
        {
            CardFactory = cardFactory;
            HandCardPoolView = handCardPoolView;
        }

        public async UniTask PresentDraw(Card[] cards)
        {
            var lastTask = UniTask.CompletedTask;
            for (var i = 0; i < cards.Length; i++)
            {
                lastTask = Draw(new PlayerCard(new PlayerId(i), cards[i]));
            }

            await lastTask;
        }

        public async UniTask PresentInitHand(HandCard[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                var handCard = cards[i].Cards;
                var lastTask = UniTask.CompletedTask;
                for (int j = 0; j < handCard.Count; j++)
                {
                    lastTask = Draw(new PlayerCard(new PlayerId(i), handCard[j]));
                }

                await lastTask;
            }
        }

        private UniTask Draw(PlayerCard playerCard)
        {
            var card = CardFactory.CreateCardView(playerCard);
            return HandCardPoolView.StoreNewCard(card);
        }

        private ICardFactory CardFactory { get; }
        private IHandCardPoolView HandCardPoolView { get; }
    }
}