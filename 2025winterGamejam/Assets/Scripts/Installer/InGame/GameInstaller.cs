using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Domain.IModel.Global;
using Domain.IModel.InGame.Player;
using Domain.UseCase.InGame;
using Installer.InGame.Player;
using Model.Global;
using Model.InGame;
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
            builder.Register<SelectedCardModel>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<PlayerCardModel>(Lifetime.Singleton).AsImplementedInterfaces();

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
            var playerCountModel = Container.Resolve<IPlayerCountModel>();
            var deckModels = Container.Resolve<IReadOnlyList<IDeckInitializable>>();
            var decks = Deck.RandomDecks(playerCountModel.PlayerCount);
            Debug.Log(deckModels.Count);
            for (int i = 0; i < playerCountModel.PlayerCount; i++)
            {
                Debug.Log($"deck : {string.Join(",", decks[i].Cards)}");
                deckModels[i].InitDeck(decks[i]);
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