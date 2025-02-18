using System;
using Utility.Structure.InGame;

namespace Domain.IPresenter.InGame
{
    public interface ICardSelectionPresenter
    {
        Action<PlayerHandCard> SelectEvent { get; set; }
    }
}