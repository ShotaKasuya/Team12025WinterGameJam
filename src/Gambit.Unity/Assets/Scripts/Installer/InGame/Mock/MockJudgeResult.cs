using Gambit.Unity.Adapter.View.InGame.CardPool;
using Gambit.Unity.Domain.Presenter.InGame;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gambit.Unity.Installer.InGame.Mock
{
    public class MockJudgeResult:LifetimeScope
    {
        [SerializeField] private DrawCardPoolView drawCardPoolView;
        [SerializeField] private WinCardPoolView winCardPoolView;
        [SerializeField] private SelectedCardPoolView selectedCardPoolView;
        
        [SerializeField] private BattleResult battleResult0;
        [SerializeField] private BattleResult battleResult1;
        [SerializeField] private BattleResult battleResult2;
        [SerializeField] private BattleResult battleResult3;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(drawCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(winCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(selectedCardPoolView).AsImplementedInterfaces();

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