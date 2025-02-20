using System;
using System.Collections.Generic;
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
        public IReadOnlyList<Card> HandCardsReader { get; }
        public Action<Card> OnAddHandCards { get; set; }
    }
    public interface IHandCardEventModel
    {
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }
    }
}