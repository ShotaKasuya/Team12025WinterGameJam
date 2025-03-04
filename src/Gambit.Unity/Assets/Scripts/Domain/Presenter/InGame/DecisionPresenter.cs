using System.Collections.Generic;
using Adapter.IView.InGame;
using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Utility.Structure.InGame;

namespace Domain.Presenter.InGame
{
    public class DecisionPresenter : IDecisionPresenter
    {
        public DecisionPresenter
        (
            IHandCardPoolView handCardPoolView,
            ISelectedCardPoolView selectedCardPoolView
        )
        {
            HandCardPoolView = handCardPoolView;
            SelectedCardPoolView = selectedCardPoolView;
        }

        public async UniTask PresentDecision(PlayerCard[] cards)
        {
            var tasks = new List<UniTask>();
            foreach (var selectedCardInfo in cards)
            {
                var handCard = HandCardPoolView.PopCardView(selectedCardInfo);

                var storeTask = SelectedCardPoolView.StoreNewCard(handCard);
                tasks.Add(storeTask);
            }
            tasks.Add(HandCardPoolView.FixPosition());

            await UniTask.WhenAll(tasks);
        }

        private IHandCardPoolView HandCardPoolView { get; }
        private ISelectedCardPoolView SelectedCardPoolView { get; }
    }
}