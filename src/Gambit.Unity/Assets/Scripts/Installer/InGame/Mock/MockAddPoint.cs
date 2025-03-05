using Gambit.Unity.Adapter.View.InGame.Ui;
using Gambit.Unity.Domain.Presenter.InGame;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gambit.Unity.Installer.InGame.Mock
{
    public class MockAddPoint : LifetimeScope
    {
        [SerializeField] private AddPointTextView addPointTextView;
        [SerializeField] private int[] presentPoint;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(addPointTextView).AsImplementedInterfaces();

            builder.Register<AddPointPresenter>(Lifetime.Singleton);
        }

        private void Start()
        {
            var presenter = Container.Resolve<AddPointPresenter>();
            var _ = presenter.PresentAddPoint(presentPoint);
        }
    }
}