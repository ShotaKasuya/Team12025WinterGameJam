using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Utility.Structure.InGame;
using KanKikuchi.AudioManager;

namespace Domain.Presenter.InGame
{
    /// <summary>
    /// デッキからカードを引く演出
    /// </summary>
    public class DrawPresenter : IDrawPresenter, IInitHandPresenter
    {
        public DrawPresenter
        (
            INewCardFactory cardFactory,
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
            SEManager.Instance.Play(SEPath.DEAL_CARDS_SE, 0.2f);
            for (int i = 0; i < cards.Length; i++)
            {
                var handCard = cards[i].Cards;
                var lastTask = UniTask.CompletedTask;
                for (int j = 0; j < handCard.Count; j++)
                {
                    lastTask = Draw(new PlayerCard(new PlayerId(i), handCard[j]));
                }
                SEManager.Instance.Play(SEPath.DEAL_CARDS_SE, 0.2f);

                await lastTask;
            }
        }

        private UniTask Draw(PlayerCard playerCard)
        {
            SEManager.Instance.Play(SEPath.DRAW_CARD_SE, 0.5f);
            var card = CardFactory.CreateCardView(playerCard);
            return HandCardPoolView.StoreNewCard(card);
        }

        private INewCardFactory CardFactory { get; }
        private IHandCardPoolView HandCardPoolView { get; }
    }
}