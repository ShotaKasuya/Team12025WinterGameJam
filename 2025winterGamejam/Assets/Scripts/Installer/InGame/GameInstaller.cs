using System.Collections.Generic;
using Domain.IModel.InGame.Player;
using Domain.IView.InGame;
using Domain.UseCase.InGame;
using Installer.InGame.Player;
using Model.InGame;
using Model.InGame.Player;
using UnityEngine;
using Utility.Module.Installer;
using Utility.Structure.InGame;
using View.InGame;

namespace Installer.InGame
{
    public class GameInstaller : InstallerBase
    {
        [SerializeField] private List<HandCardPositionsView> cardPositionsView;
        [SerializeField] private PlayerInstaller playerInstaller;

        protected override void CustomConfigure()
        {
            // Model
            var gameStateModel = new GameStateModel();
            var judgeResultModel = new JudgeResultModel();

            var selectedCardModels = new List<ISelectedCardModel>();
            var playerConditionModel = new List<IConditionModel>();

            var decks = Deck.RandomDecks(2);
            for (int i = 0; i < 2; i++)
            {
                var player = CreatePlayer(new PlayerId(i), gameStateModel, cardPositionsView[i], decks[i]);
                selectedCardModels.Add(player.GetInstance<ISelectedCardModel>());
                playerConditionModel.Add(player.GetInstance<IConditionModel>());
            }

            // UseCase
            var cardJudgeCase = new CardJudgeCase(selectedCardModels.ToArray(), judgeResultModel,
                playerConditionModel.ToArray());
            RegisterEntryPoints(cardJudgeCase);

            gameStateModel.SetGameState(GameStateType.DrawCard);
            gameStateModel.SetGameState(GameStateType.DrawCard);
            gameStateModel.SetGameState(GameStateType.DrawCard);
            gameStateModel.SetGameState(GameStateType.DrawCard);
        }

        private PlayerInstaller CreatePlayer(PlayerId playerId, GameStateModel gameStateModel,
            ICardPositionsView positionsView, Deck playerDeck)
        {
            var instance = Instantiate(playerInstaller);
            instance.Inject(
                new PlayerIdModel(playerId),
                gameStateModel,
                positionsView,
                playerDeck
            );
            return instance;
        }
    }
}