using Domain.IModel.InGame.Player;
using Domain.IView.InGame;
using Domain.Presenter.InGame.Player;
using Domain.UseCase.InGame.Player;
using Model.InGame;
using Model.InGame.Player;
using UnityEngine;
using Utility.Module.Installer;
using Utility.Structure.InGame;
using View.InGame.Player;
using PlayerConditionModel = Model.InGame.Player.PlayerConditionModel;

namespace Installer.InGame.Player
{
    public class PlayerInstaller : InstallerBase
    {
        [SerializeField] private ProductCardView productCardView;

        private IPlayerIdModel _playerIdModel;
        private GameStateModel _gameStateModel;
        private ICardPositionsView _handCardPositionsView;
        private Deck _deck;

        public void Inject
        (
            IPlayerIdModel playerIdModel,
            GameStateModel gameStateModel,
            ICardPositionsView handCardPositionsView,
            Deck deck
        )
        {
            _playerIdModel = playerIdModel;
            _gameStateModel = gameStateModel;
            _handCardPositionsView = handCardPositionsView;
            _deck = deck;
        }

        protected override void CustomConfigure()
        {
            // Factory
            var cardFactory = new CardFactory(productCardView);

            // Model
            var handCardModel = new PlayerHandCardModel();
            var deckModel = new PlayerDeckModel(_deck);
            var conditionModel = new PlayerConditionModel();
            RegisterEntryPoints(handCardModel);
            RegisterInstance<ISelectedCardModel, PlayerHandCardModel>(handCardModel);
            RegisterInstance<IConditionModel, PlayerConditionModel>(conditionModel);
            
            // Presenter
            var cardPresenter =
                new NewCardPresenter(cardFactory, handCardModel, _handCardPositionsView);
            var selectedCardPresenter = new SelectedCardPresenter(cardFactory, handCardModel);
            RegisterEntryPoints(cardPresenter);
            RegisterEntryPoints(selectedCardPresenter);

            // UseCase
            var drawCardCase = new DrawCardCase(deckModel, handCardModel, _gameStateModel, _gameStateModel);
            // スコアの加算
            RegisterEntryPoints(drawCardCase);
        }
    }
}