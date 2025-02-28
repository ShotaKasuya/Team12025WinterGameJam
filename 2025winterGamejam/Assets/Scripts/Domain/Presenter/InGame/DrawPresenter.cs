using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Utility.Structure.InGame;

namespace Domain.Presenter.InGame
{
    /// <summary>
    /// デッキからカードを引く演出
    /// </summary>
    public class DrawPresenter : IDrawPresenter
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
            for (var i = 0; i < cards.Length; i++)
            {
                var id = new PlayerId(i);
                var card = CardFactory.CreateCardView(new PlayerCard(id, cards[i]));
                await HandCardPoolView.StoreNewCard(id, card);
            }
        }

        private INewCardFactory CardFactory { get; }
        private IHandCardPoolView HandCardPoolView { get; }
    }
}