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
using View.InGame.Player;

namespace Installer.InGame.Player
{
    public class PlayerInstaller : InstallerBase
    {
        [SerializeField] private ProductCardView productCardView;

        private IPlayerIdModel _playerIdModel;
        private GameStateModel _gameStateModel;
        private HandCardPositionsView _handCardPositionsView;

        public void Inject(IPlayerIdModel playerIdModel, GameStateModel gameStateModel,
            HandCardPositionsView handCardPositionsView)
        {
            _playerIdModel = playerIdModel;
            _gameStateModel = gameStateModel;
            _handCardPositionsView = handCardPositionsView;
        }

        protected override void CustomConfigure()
        {
            // Factory
            var cardFactory = new CardFactory(productCardView);
            
            // Model
            var handCardModel = new PlayerHandCardModel();
            var deckModel = new PlayerDeckModel();
            RegisterEntryPoints(handCardModel);

            // Presenter
            var cardPresenter =
                new NewCardPresenter(cardFactory, handCardModel, _handCardPositionsView);
            RegisterEntryPoints(cardPresenter);
            var selectedCardPresenter = new SelectedCardPresenter(cardFactory, handCardModel);

            // UseCase
            var drawCardCase = new DrawCardCase(deckModel, handCardModel, _gameStateModel, _gameStateModel);
            // スコアの加算
            RegisterEntryPoints(drawCardCase);

            deckModel.InitDeck(Deck.SortedDeck(new List<Suit> { Suit.Clubs, Suit.Diamonds }));
            _gameStateModel.SetGameState(GameStateType.DrawCard);
            _gameStateModel.SetGameState(GameStateType.DrawCard);
            _gameStateModel.SetGameState(GameStateType.DrawCard);
            _gameStateModel.SetGameState(GameStateType.DrawCard);
        }
    }
}