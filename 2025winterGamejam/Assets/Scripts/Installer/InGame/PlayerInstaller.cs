using Domain.IModel.InGame.Player;
using Domain.UseCase.InGame.Player;
using IView.InGame;
using Model.InGame;
using Model.InGame.Player;
using Presenter.InGame.Player;
using UnityEngine;
using Utility.Module.Installer;
using View.InGame;

namespace Installer.InGame
{
    public class PlayerInstaller: InstallerBase
    {
        [SerializeField] private HandCardPositionsView handCardPositionsView;
        [SerializeField] private FactorableCardView factorableCardView;

        [HideInInspector] public IPlayerIdModel PlayerIdModel;
        [HideInInspector] public GameStateModel GameStateModel;
        
        protected override void CustomConfigure()
        {
            Debug.Log($"Game State: {GameStateModel is null}");
            Debug.Log($"Player Id Model: {PlayerIdModel is null}");
            
            // Model
            var handCardModel = new PlayerHandCardModel();
            var deckModel = new PlayerDeckModel();
            
            // Presenter
            var cardPresenter = new CardPresenter(PlayerIdModel, handCardModel, handCardPositionsView, factorableCardView);
            
            // UseCase
            var selectCardCase = new SelectCardCase(cardPresenter, handCardModel);
            var drawCardCase = new DrawCardCase(deckModel, handCardModel, GameStateModel, GameStateModel );
            // スコアの加算
        }
    }
}