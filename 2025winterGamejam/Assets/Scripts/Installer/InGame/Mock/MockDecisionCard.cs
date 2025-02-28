using Domain.Presenter.InGame;
using VContainer;
using VContainer.Unity;

namespace Installer.InGame.Mock
{
    public class MockDecisionCard: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {

            builder.Register<DecisionPresenter>(Lifetime.Singleton);
        }
    }
}