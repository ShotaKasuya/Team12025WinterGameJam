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
    public class MockDrawCard : LifetimeScope
    {
        [SerializeField] private CardView cardView;
        [SerializeField] private HandCardPoolView handCardPoolView;

        [SerializeField] private PlayerCard[] cards0;
        [SerializeField] private PlayerCard[] cards1;
        [SerializeField] private PlayerCard[] cards2;
        [SerializeField] private PlayerCard[] cards3;

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