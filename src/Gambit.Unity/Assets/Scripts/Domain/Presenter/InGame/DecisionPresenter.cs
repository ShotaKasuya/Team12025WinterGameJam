using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Domain.Presenter.InGame
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
                handCard.ShowFace();

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