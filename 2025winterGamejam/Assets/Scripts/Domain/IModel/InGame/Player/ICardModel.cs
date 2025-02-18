using System.Collections.Generic;
using Structure.InGame;
using System;


namespace Domain.IModel.InGame.Player
{
    public interface IDeckModelPlayer
    {
        public Deck Deck{get;}
    }
    public interface IMutHandCardModel : IHandCardModel
    {
        public void StoreNewCard(int playerId, Card card);
    }
    public interface IHandCardModelPlayer
    {
        public HandCard HandCards { get; }
    }
    public interface IHandCardEventModel
    {
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }
    }
}