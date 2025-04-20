using Gambit.Unity.Adapter.Controller.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Adapter.Model.Global;
using Gambit.Unity.Adapter.Model.InGame;
using Gambit.Unity.Adapter.Model.InGame.Judgement;
using Gambit.Unity.Adapter.View.InGame;
using Gambit.Unity.Adapter.View.InGame.CardPool;
using Gambit.Unity.Adapter.View.InGame.Ui;
using Gambit.Unity.Domain.Flow.InGame;
using Gambit.Unity.Domain.Presenter.InGame;
using Gambit.Unity.Domain.UseCase.InGame;
using Gambit.Unity.Utility.Structure.InGame.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gambit.Unity.Installer.InGame
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private CardView baseCardView;
        [SerializeField] private StartImageView startImageView;
        [SerializeField] private AddPointTextView addPointTextView;
        [SerializeField] private HandCardPoolView cardPositionsView;
        [SerializeField] private SelectedCardPoolView selectedCardPoolView;
        [SerializeField] private WinCardPoolView winCardPoolView;
        [SerializeField] private DrawCardPoolView drawCardPoolView;
        [SerializeField] private ExplanationImageView explanationImageView;
        [SerializeField] private GameResultView gameResultView;
        [SerializeField] private RemainCardView remainCardView;
        [SerializeField] private ScoreView scoreView;

        [SerializeField] private SettingModel settingModel;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("configure");
            
            // View
            builder.UseComponents(componentsBuilder =>
            {
                componentsBuilder.AddInstance(gameResultView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(baseCardView).As<ProductCardView>();
                componentsBuilder.AddInstance(drawCardPoolView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(winCardPoolView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(startImageView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(explanationImageView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(addPointTextView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(cardPositionsView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(selectedCardPoolView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(remainCardView).AsImplementedInterfaces();
                componentsBuilder.AddInstance(scoreView).AsImplementedInterfaces();
            });
            builder.Register<CardFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            
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

            // Controller
            builder.UseEntryPoints(pointsBuilder =>
            {
                pointsBuilder.Add<SelectionController>();
                pointsBuilder.Add<ReceiveOtherPlayerCardController>();
                pointsBuilder.Add<CardExplanationController>();
                pointsBuilder.Add<RemainCardController>();
                pointsBuilder.Add<ScoreController>();
                pointsBuilder.Add<UseHandCardController>();
            });

            // Presenter
            builder.Register<DrawPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<JudgeResultPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AddPointPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<DecisionPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameStartPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameEndPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
            
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