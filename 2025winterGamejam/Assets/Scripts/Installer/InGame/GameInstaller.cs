using System.Collections.Generic;
using System.Linq;
using Adapter.InGame;
using Domain.IPresenter.InGame;
using Domain.UseCase.InGame;
using IView.InGame;
using Model.InGame;
using Module.Installer;
using Presenter.InGame;
using UnityEngine;
using View.InGame;

namespace Installer.InGame
{
    public class GameInstaller : InstallerBase
    {
        [SerializeField] private List<HandCardPositionsView> cardPositionsView;
        [SerializeField] private FactorableCardView factorableCardView;

        protected override void CustomConfigure()
        {
            // Model
            var deckModel = new PlayerCardModel();
            var gameStateModel = new GameStateModel();
            var judgeResultModel = new JudgeResultModel();
            var playerConditionModel = new PlayerConditionModel();

            // // Presenter
            // var cardSelectionPresenter = new PlayerSelectionPresenter();
            // var cardPresenter = new CardPresenter(cardPositionsView.Cast<ICardPositionsView>().ToList());

            // // Adapter
            // var cardFactory = new CardFactory(factorableCardView,
            //     new ICardReceivable[] { cardSelectionPresenter, cardPresenter });

            // UseCase
            // var cardSelectedCase = new 
            // var makeNewCardCase = new MakeNewCardCase(deckModel, cardFactory);
            // var drawCardCase = new DrawCardCase(deckModel, deckModel, gameStateModel, gameStateModel);
            // var cardJudgeCase = new CardJudgeCase(selectionView, judgeResultModel, playerConditionModel);
        }
    }
}