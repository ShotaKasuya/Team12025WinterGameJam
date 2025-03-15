using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Adapter.Linker.InGame;
using Gambit.Unity.Adapter.Model.Global;
using Gambit.Unity.Adapter.Model.InGame;
using Gambit.Unity.Adapter.Model.InGame.Judgement;
using Gambit.Unity.Adapter.View.InGame;
using Gambit.Unity.Adapter.View.InGame.CardPool;
using Gambit.Unity.Adapter.View.InGame.Ui;
using Gambit.Unity.Domain.Flow.InGame;
using Gambit.Unity.Domain.Presenter.InGame;
using Gambit.Unity.Domain.UseCase.InGame;
using Gambit.Unity.Structure.Utility.InGame.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gambit.Unity.Installer.InGame
{
    public class GameTestInstaller: LifetimeScope
    {
        [SerializeField] private CardView baseCardView;
        [SerializeField] private StartImageView startImageView;
        [SerializeField] private AddPointTextView addPointTextView;
        [SerializeField] private HandCardPoolView cardPositionsView;
        [SerializeField] private SelectedCardPoolView selectedCardPoolView;
        [SerializeField] private WinCardPoolView winCardPoolView;
        [SerializeField] private DrawCardPoolView drawCardPoolView;
        [SerializeField] private ExplanationImageView explanationImageView;

        [SerializeField] private SettingModel settingModel;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("configure");
            
            // View
            builder.RegisterComponent(baseCardView).As<ProductCardView>();
            builder.RegisterComponent(drawCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(winCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(startImageView).AsImplementedInterfaces();
            builder.RegisterComponent(addPointTextView).AsImplementedInterfaces();
            builder.RegisterComponent(cardPositionsView).AsImplementedInterfaces();
            builder.RegisterComponent(selectedCardPoolView).AsImplementedInterfaces();
            builder.RegisterComponent(explanationImageView).AsImplementedInterfaces();
            builder.Register<DebugCardFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // Model
            builder.RegisterInstance(settingModel).AsImplementedInterfaces();
            builder.Register<GameStateModel>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<JudgeResultModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerCountModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<SelectedCardModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ConditionModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DeckModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<HandCardModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<ScoreModel>(Lifetime.Singleton).AsImplementedInterfaces();

            // Linker
            builder.RegisterEntryPoint<DebugSelectionLinker>();
            builder.RegisterEntryPoint<PlayerCardTransferObjectLinker>();
            builder.RegisterEntryPoint<CardExplanationLinker>();

            // Presenter
            builder.Register<DrawPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<JudgeResultPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AddPointPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DecisionPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameStartPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            
            // UseCase
            builder.Register<DeckHandCardInitializeCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IsGameEndCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IsReadyJudgeCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AddPointCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DrawCardCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CardJudgeCase>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<IsPlayerWinCase>(Lifetime.Singleton).AsImplementedInterfaces();

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