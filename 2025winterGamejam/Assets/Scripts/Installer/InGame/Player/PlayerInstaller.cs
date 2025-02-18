using System.Collections.Generic;
using Domain.IModel.InGame.Player;
using Domain.UseCase.InGame.Player;
using IView.InGame;
using Model.InGame;
using Model.InGame.Player;
using Presenter.InGame.Player;
using UnityEngine;
using Utility.Module.Installer;
using Utility.Structure.InGame;
using View.InGame;

namespace Installer.InGame.Player
{
    public class PlayerInstaller : InstallerBase
    {
        [SerializeField] private FactorableCardView factorableCardView;

        [HideInInspector] public IPlayerIdModel PlayerIdModel;
        [HideInInspector] public GameStateModel GameStateModel;
        [HideInInspector] public HandCardPositionsView handCardPositionsView;

        protected override void CustomConfigure()
        {
            // Model
            var handCardModel = new PlayerHandCardModel();
            var deckModel = new PlayerDeckModel();
            RegisterEntryPoints(handCardModel);

            // Presenter
            var cardPresenter =
                new CardPresenter(PlayerIdModel, handCardModel, handCardPositionsView, factorableCardView);
            RegisterEntryPoints(cardPresenter);

            // UseCase
            var selectCardCase = new SelectCardCase(cardPresenter, handCardModel);
            var drawCardCase = new DrawCardCase(deckModel, handCardModel, GameStateModel, GameStateModel);
            // スコアの加算
            RegisterEntryPoints(selectCardCase);
            RegisterEntryPoints(drawCardCase);

            deckModel.InitDeck(Deck.SortedDeck(new List<Suit>() { Suit.Clubs, Suit.Diamonds }));
            GameStateModel.SetGameState(GameStateType.DrawCard);
            GameStateModel.SetGameState(GameStateType.DrawCard);
            GameStateModel.SetGameState(GameStateType.DrawCard);
            GameStateModel.SetGameState(GameStateType.DrawCard);
        }
    }
}