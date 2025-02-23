using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Domain.IModel.Global;
using Domain.IModel.InGame.Judgement;
using Domain.UseCase.InGame;
using Installer.InGame.Player;
using Model.Global;
using Model.InGame;
using Model.InGame.Judgement;
using Model.InGame.Player;
using UnityEngine;
using Utility.Structure.InGame;
using VContainer;
using VContainer.Unity;
using View.InGame;

namespace Installer.InGame
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private List<HandCardPositionsView> cardPositionsView;
        [SerializeField] private PlayerInstaller playerInstaller;

        protected override void Configure(IContainerBuilder builder)
        {
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

            // Model for PlayerInstaller
            builder.Register<PlayerScoreModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerHandCardModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerDeckModel>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlayerConditionModel>(Lifetime.Scoped).AsImplementedInterfaces();

            // UseCase
            builder.UseEntryPoints(pointsBuilder =>
            {
                pointsBuilder.Add<CardJudgeCase>();
                pointsBuilder.Add<AddPlayerCase>();
            });
        }

        private async void Start()
        {
            var deckModels = Container.Resolve<IMutDeckModel>();
            var playerCountModel = Container.Resolve<IPlayerCountModel>();
            var decks = Deck.RandomDecks(playerCountModel.PlayerCount);
            Debug.Log(deckModels.DeckReader.Count);
            for (int i = 0; i < playerCountModel.PlayerCount; i++)
            {
                Debug.Log($"deck : {string.Join(",", decks[i].Cards)}");
                deckModels.Decks[i] =decks[i];
            }
            
            await UniTask.DelayFrame(1);

            var gameStateModel = Container.Resolve<GameStateModel>();
            gameStateModel.SetGameState(GameStateType.DrawCard);
            gameStateModel.SetGameState(GameStateType.DrawCard);
            gameStateModel.SetGameState(GameStateType.DrawCard);
            gameStateModel.SetGameState(GameStateType.DrawCard);
        }
    }
}