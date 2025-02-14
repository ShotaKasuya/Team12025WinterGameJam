using System.Collections.Generic;
using Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface IDeckModel
    {
        public List<Deck> Decks{get;}
    }

    public interface IHandCard
    {
        public List<HandCard> HandCards{get;}
    }

    public class MockDeckModel: IDeckModel
    {
        public List<Deck> Decks { get; private set; } = new List<Deck>();

        public void SetUpDeck(List<Deck> decks)
        {
            Decks = decks;
        }
    }

    public class MockHandCardModel : IHandCard
    {
        public List<HandCard> HandCards { get; private set; } = new List<HandCard>();

        public void SetUpHandCard(List<HandCard> handCards)
        {
            HandCards = handCards;
        }
    }
}