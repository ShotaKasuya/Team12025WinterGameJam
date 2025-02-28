using System.Collections.Generic;
using Adapter.Model.Global;
using Adapter.Model.InGame;
using Adapter.Model.InGame.Judgement;
using Adapter.View.CardPrefabdb;
using Adapter.View.InGame;
using Adapter.View.InGame.CardPool;
using Domain.Flow.InGame;
using Domain.Presenter.InGame;
using Domain.UseCase.InGame;
using UnityEngine;
using Utility.Structure.InGame.StateMachine;
using VContainer;
using VContainer.Unity;

namespace Installer.InGame
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private List<HandCardPositionsView> cardPositionsView;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("configure");
            
            // View
            builder.Register<CardFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<HandCardPoolView>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DrawCardPoolView>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<WinCardPoolView>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // Model
            builder.Register<GameStateModel>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<JudgeResultModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IdProvideModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerCountModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SelectedCardModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ConditionModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DeckModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<HandCardModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ScoreModel>(Lifetime.Singleton).AsImplementedInterfaces();


            // Presenter
            builder.Register<DrawPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<JudgeResultPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AddPointPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DecisionPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameStartPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // UseCase
            builder.Register<IsGameEndCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IsReadyJudgeCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AddPointCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DrawCardCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CardJudgeCase>(Lifetime.Singleton).AsImplementedInterfaces();

            // Flow
            builder.Register<AddPointStateFlow>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DecisionCardStateFlow>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DrawCardStateFlow>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<EndStateFlow>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<InitStateFlow>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<JudgeStateFlowCase>(Lifetime.Singleton).AsImplementedInterfaces();

            // StateMachine
            builder.Register<GameState>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterEntryPoint<InGameStateMachine>();
        }
    }
}