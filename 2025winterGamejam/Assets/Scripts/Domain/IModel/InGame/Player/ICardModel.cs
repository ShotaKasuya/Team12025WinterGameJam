using System;
using ObservableCollections;
using Utility.Structure.InGame;


namespace Domain.IModel.InGame.Player
{
    public interface IDeckInitializable
    {
        public void InitDeck(Deck deck);
    }
    public interface IDeckModelPlayer
    {
        public Deck Deck{get;}
    }
    public interface IMutHandCardModel : IHandCardModel
    {
        public void StoreNewCard(Card card);
    }
    public interface IHandCardModel
    {
        public ObservableList<Card> HandCards { get; }
    }
    public interface IHandCardEventModel
    {
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }
    }
}