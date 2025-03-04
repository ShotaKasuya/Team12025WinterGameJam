using Adapter.IModel.InGame.Player;
using Adapter.IView.InGame;
using Adapter.Linker.InGame;
using Adapter.View.InGame;
using Adapter.View.InGame.CardPool;
using Domain.Presenter.InGame;
using UnityEngine;
using Utility.Structure.InGame;
using VContainer;
using VContainer.Unity;

namespace Installer.InGame.Mock
{
    public class MockDrawCard : LifetimeScope
    {
        [SerializeField] private CardView cardView;
        [SerializeField] private HandCardPoolView handCardPoolView;

        [SerializeField] private Card[] cards0;
        [SerializeField] private Card[] cards1;
        [SerializeField] private Card[] cards2;
        [SerializeField] private Card[] cards3;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(cardView).As<ProductCardView>();
            builder.RegisterComponent(handCardPoolView).AsImplementedInterfaces();
            builder.RegisterInstance(new MockPlayerIdModel()).AsImplementedInterfaces();

            builder.Register<DrawPresenter>(Lifetime.Singleton);
        }

        private async void Start()
        {
            var factory = Container.Resolve<DrawPresenter>();
            await factory.PresentDraw(cards0);
            await factory.PresentDraw(cards1);
            await factory.PresentDraw(cards2);
            await factory.PresentDraw(cards3);
        }
    }
}