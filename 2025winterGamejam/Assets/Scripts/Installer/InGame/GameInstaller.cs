using System.Collections.Generic;
using System.Linq;
using Domain.IView.InGame;
using Domain.UseCase.InGame;
using Domain.UseCase.InGame.Flow;
using Installer.InGame.Player;
using Model.Global;
using Model.InGame;
using Model.InGame.Judgement;
using Model.InGame.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using View.InGame;
using View.InGame.Player;

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
                pointsBuilder.Add<InitStateFlowCase>();
                pointsBuilder.Add<DecisionCardStateFlowCase>();
                pointsBuilder.Add<JudgeStateFlowCase>();
                pointsBuilder.Add<AddPointStateFlowCase>();
            });
        }
    }
}