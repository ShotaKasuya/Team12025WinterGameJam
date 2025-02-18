using Domain.IModel.InGame.Player;
using IView.InGame;

namespace Presenter.InGame.Player
{
    public class CardPresenter
    {
        public CardPresenter
        (
            IHandCardModel handCardModel,
            FactorableCardView factorableCardView
        )
        {
            
        }
        
        
        
        private IHandCardModel HandCardModel { get; }
        private FactorableCardView FactorableCardView { get; }
    }
}