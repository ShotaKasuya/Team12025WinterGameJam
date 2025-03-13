using Gambit.Unity.Adapter.Linker.OutGame;
using Gambit.Unity.Adapter.View.OutGame.Title;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gambit.Unity.Installer.OutGame
{
    public class TitleInstaller: LifetimeScope
    {
        [SerializeField] private MatchConfPanelView matchConfPanelView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(matchConfPanelView).AsImplementedInterfaces();

            builder.RegisterEntryPoint<MatchingLinker>();
        }
    }
}