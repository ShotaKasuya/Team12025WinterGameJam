using System;
using System.Collections.Generic;
using Structure.InGame;

namespace Domain.IModel.InGame
{
    /// <summary>
    /// 各プレイヤーのデッキ
    /// </summary>
    public interface IDeckModel
    {
        public List<Deck> Decks { get; }
    }

    /// <summary>
    /// 各プレイヤーの手札
    /// </summary>
    public interface IMutHandCardModel : IHandCardModel
    {
        public void StoreNewCard(Card card);
    }
    public interface IHandCardModel
    {
        public List<HandCard> HandCards { get; }
    }
    public interface IHandCardEventModel
    {
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }
    }

    public class MockDeckModel : IDeckModel
    {
        public List<Deck> Decks { get; private set; } = new List<Deck>();

        public void SetUpDeck(List<Deck> decks)
        {
            Decks = decks;
        }
    }

    public class MockHandCardModelModel : IHandCardModel
    {
        public List<HandCard> HandCards { get; private set; } = new List<HandCard>();

        public void SetUpHandCard(List<HandCard> handCards)
        {
            HandCards = handCards;
        }
    }
}