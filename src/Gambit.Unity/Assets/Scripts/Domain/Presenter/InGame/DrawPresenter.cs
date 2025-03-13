using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Structure.Utility.InGame;
using KanKikuchi.AudioManager;

namespace Gambit.Unity.Domain.Presenter.InGame
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
            SEManager.Instance.Play(SEPath.DEAL_CARDS_SE, 0.5f);

            for (int i = 0; i < cards.Length; i++)
            {
                var handCard = cards[i].Cards;
                var lastTask = UniTask.CompletedTask;
                for (int j = 0; j < handCard.Count; j++)
                {
                    lastTask = Draw(new PlayerCard(new PlayerId(i), handCard[j]));
                }
                SEManager.Instance.Play(SEPath.DEAL_CARDS_SE, 0.5f);
                await lastTask;
            }
            

        }

        private UniTask Draw(PlayerCard playerCard)
        {
            SEManager.Instance.Play(SEPath.DRAW_CARD_SE);
            var card = CardFactory.CreateCardView(playerCard);
            return HandCardPoolView.StoreNewCard(card);
        }

        private ICardFactory CardFactory { get; }
        private IHandCardPoolView HandCardPoolView { get; }
    }
}