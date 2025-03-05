using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.ILinker.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Adapter.View.InGame;
using Gambit.Unity.Adapter.View.InGame.CardPool;
using Gambit.Unity.Domain.Presenter.InGame;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gambit.Unity.Installer.InGame.Mock
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
            builder.RegisterComponent(cardView).As<ProductCardView>();
            builder.RegisterComponent(handCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(selectedCardPoolView).AsImplementedInterfaces();
            builder.RegisterInstance(new MockPlayerIdModel()).AsImplementedInterfaces();

            builder.Register<CardFactory>(Lifetime.Singleton);

            builder.Register<DecisionPresenter>(Lifetime.Singleton);
        }

        private async void Start()
        {
            var lastTask = UniTask.CompletedTask;
            var factory = Container.Resolve<CardFactory>();
            foreach (var card in cards)
            {
                var instance = factory.CreateCardView(card);
                lastTask = handCardPoolView.StoreNewCard(instance);
            }

            await lastTask;

            var presenter = Container.Resolve<DecisionPresenter>();
            await presenter.PresentDecision(new[] { selection0, selection1 });
        }
    }
}