using System;
using System.Collections.Generic;
using Utility.Structure.InGame;

namespace Adapter.IModel.InGame.Player
{
    /// <summary>
    /// デッキインターフェース
    /// </summary>
    public interface IDeckInitializable
    {
        public void InitDeck(Deck deck);
    }

    public interface IPlayerDeckModel
    {
        public Deck Deck { get; }
    }

    public class MockPlayerDeckModel: IPlayerDeckModel, IDeckInitializable
    {
        public void InitDeck(Deck deck)
        {
            Deck = deck;
        }
        public Deck Deck { get; private set; }
    }

    public interface IMutPlayerHandCardModel : IPlayerHandCardModel
    {
        public void StoreNewCard(Card card);
    }

    public interface IPlayerHandCardModel
    {
        public IReadOnlyList<Card> HandCardsReader { get; }
        public Action<Card> OnAddHandCards { get; set; }
    }

    public interface IHandCardEventModel
    {
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }
    }
}