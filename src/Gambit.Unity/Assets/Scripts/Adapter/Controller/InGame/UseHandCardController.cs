using System;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Controller.InGame
{
    public class UseHandCardController : IInitializable, IDisposable
    {
        public UseHandCardController
        (
            IHandCardPoolView handCardPoolView,
            IHandCardModel handCardModel
        )
        {
            HandCardPoolView = handCardPoolView;
            HandCardModel = handCardModel;
        }

        public void Initialize()
        {
            HandCardPoolView.OnPop += RemoveUsedCard;
        }

        private void RemoveUsedCard(ProductCardView productCardView)
        {
            var playerCard = productCardView.Card;
            HandCardModel.HandCardReader[playerCard.PlayerId.Id].Cards.Remove(playerCard);
        }

        private IHandCardPoolView HandCardPoolView { get; }
        private IHandCardModel HandCardModel { get; }

        public void Dispose()
        {
            HandCardPoolView.OnPop -= RemoveUsedCard;
        }
    }
}