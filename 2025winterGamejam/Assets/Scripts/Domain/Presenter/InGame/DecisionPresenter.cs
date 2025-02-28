using System.Linq;
using Adapter.IModel.InGame.Judgement;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;

namespace Domain.Presenter.InGame
{
    public class DecisionPresenter : IDecisionPresenter
    {
        public DecisionPresenter
        (
            ISelectedCardModel selectedCardModel,
            IHandCardPoolView handCardPoolView,
            ISelectedCardPoolView selectedCardPoolView
        )
        {
            SelectedCardModel = selectedCardModel;
            HandCardPoolView = handCardPoolView;
            SelectedCardPoolView = selectedCardPoolView;
        }

        public async UniTask PresentDecision()
        {
            var selectedCards = SelectedCardModel.SelectedCards
                .Select(x => x.Unwrap());
            foreach (var selectedCardInfo in selectedCards)
            {
                var handCard = HandCardPoolView.PopCardView(selectedCardInfo);

                await SelectedCardPoolView.StoreNewCard(handCard);
            }
        }

        private ISelectedCardModel SelectedCardModel { get; }
        private IHandCardPoolView HandCardPoolView { get; }
        private ISelectedCardPoolView SelectedCardPoolView { get; }
    }
}