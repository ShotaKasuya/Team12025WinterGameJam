using System;
using System.Collections.Generic;
using Utility.Structure.InGame;

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
        public void StoreNewCard(int playerId, Card card);
    }

    public interface IHandCardModel
    {
        public IReadOnlyList<HandCard> HandCards { get; }
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
        public IReadOnlyList<HandCard> HandCards { get; private set; } = new List<HandCard>();

        public void SetUpHandCard(List<HandCard> handCards)
        {
            HandCards = handCards;
        }
    }
}