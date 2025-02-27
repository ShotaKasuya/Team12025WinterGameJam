using System.Collections.Generic;
using System.Linq;
using Adapter.IView.InGame;
using Adapter.Model.Global;
using Adapter.Model.InGame;
using Adapter.Model.InGame.Judgement;
using Adapter.Model.InGame.Player;
using Adapter.View.InGame;
using Adapter.View.InGame.Player;
using Domain.UseCase.InGame;
using Installer.InGame.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installer.InGame
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private List<HandCardPositionsView> cardPositionsView;
        [SerializeField] private PlayerInstaller playerInstaller;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(cardPositionsView.Cast<ICardPositionsView>().ToList());
            
            builder.RegisterInstance(playerInstaller).As<MonoBehaviour>();
            // Model
            builder.Register<GameStateModel>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<JudgeResultModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IdProvideModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerCountModel>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // Model for GameInstaller
            builder.Register<SelectedCardModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ConditionModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DeckModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<HandCardModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ScoreModel>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // View for PlayerInstaller
            builder.Register<PlayerHandCardPositionView>(Lifetime.Scoped).AsImplementedInterfaces();

            // Model for PlayerInstaller
            builder.Register<PlayerScoreModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerHandCardModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerDeckModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerConditionModel>(Lifetime.Scoped).AsImplementedInterfaces();

            // UseCase
            builder.UseEntryPoints(pointsBuilder =>
            {
                pointsBuilder.Add<InitDeckCase>();
                pointsBuilder.Add<CardJudgeCase>();
                pointsBuilder.Add<AddPlayerCase>();
                
                // Flow
            });
        }
    }
}