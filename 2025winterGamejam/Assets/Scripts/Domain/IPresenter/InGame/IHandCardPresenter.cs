using System;
using Structure.InGame;

namespace Domain.IPresenter.InGame
{
    public interface IHandCardPresenter
    {
        Action<HandCardDesc> OnSelectCard { get; set; }
    }

    public struct HandCardDesc
    {
        public HandCardDesc
        (
            int id, Card card
        )
        {
            Card = card;
            Id = id;
        }

        public Card Card { get; }
        public int Id { get; }
    }
}