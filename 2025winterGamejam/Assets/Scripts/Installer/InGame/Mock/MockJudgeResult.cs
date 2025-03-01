using Adapter.View.InGame.CardPool;
using Adapter.View.InGame.Ui;
using Domain.Presenter.InGame;
using UnityEngine;
using Utility.Structure.InGame;
using VContainer;
using VContainer.Unity;

namespace Installer.InGame.Mock
{
    public class MockJudgeResult:LifetimeScope
    {
        [SerializeField] DrawCardPoolView drawCardPoolView;
        [SerializeField] WinCardPoolView winCardPoolView;
        [SerializeField] HandCardPoolView handCardPoolView;
        [SerializeField] BattleResult battleResult0;
        [SerializeField] BattleResult battleResult1;
        [SerializeField] BattleResult battleResult2;
        [SerializeField] BattleResult battleResult3;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(drawCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(handCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(winCardPoolView).AsImplementedInterfaces();

            builder.Register<JudgeResultPresenter>(Lifetime.Singleton);
        }

        private async void Start()
        {
            var presenter = Container.Resolve<JudgeResultPresenter>();
            await presenter.PresentResult(battleResult0);
            await presenter.PresentResult(battleResult1);
            await presenter.PresentResult(battleResult2);
            await presenter.PresentResult(battleResult3);
        }
    }
}