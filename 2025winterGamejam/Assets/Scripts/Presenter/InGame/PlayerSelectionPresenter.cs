using System;
using Domain.IPresenter.InGame;
using IView.InGame;
using Utility.Structure.InGame;

namespace Presenter.InGame
{
    public class PlayerSelectionPresenter: ICardSelectionPresenter, ICardReceivable
    {
        public Action<PlayerHandCard> SelectEvent { get; set; }
        public void ReceiveCard(ICardView cardView)
        {
            SelectEvent += cardView.SelectionEvent;
        }
        public void ReleaseCard(ICardView cardView)
        {
            SelectEvent -= cardView.SelectionEvent;
        }
    }
}