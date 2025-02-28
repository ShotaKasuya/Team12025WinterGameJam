using Adapter.IView.InGame;
using Adapter.View.CardPrefabdb;
using Adapter.View.InGame;
using Adapter.View.InGame.CardPool;
using Cysharp.Threading.Tasks;
using Domain.Presenter.InGame;
using UnityEngine;
using Utility.Structure.InGame;
using VContainer;
using VContainer.Unity;

namespace Installer.InGame.Mock
{
    public class MockDecisionCard : LifetimeScope
    {
        [SerializeField] private CardView cardView;
        [SerializeField] private HandCardPoolView handCardPoolView;
        [SerializeField] private SelectedCardPoolView selectedCardPoolView;

        [SerializeField] private PlayerCard[] cards;
        [SerializeField] private PlayerCard selection0;
        [SerializeField] private PlayerCard selection1;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(cardView).As<NewProductCardView>();
            builder.RegisterComponent(handCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(selectedCardPoolView).AsImplementedInterfaces();

            builder.Register<CardFactory>(Lifetime.Singleton);

            builder.Register<DecisionPresenter>(Lifetime.Singleton);
        }

        private async void Start()
        {
            var task = UniTask.CompletedTask;
            var factory = Container.Resolve<CardFactory>();
            foreach (var card in cards)
            {
                var instance = factory.CreateCardView(card);
                task = handCardPoolView.StoreNewCard(instance);
            }

            await task;

            var presenter = Container.Resolve<DecisionPresenter>();
            await presenter.PresentDecision(new[] { selection0, selection1 });
        }
    }
}