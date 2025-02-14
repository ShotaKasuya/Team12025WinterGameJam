using System.Collections.Generic;
using Domain.IModel.InGame;
using Domain.UseCase.InGame;
using NUnit.Framework;
using Structure.InGame;

namespace Tests.EditModeTest.InGame
{
    public class DrawCardTest
    {
        [SetUp]
        public void SetUp()
        {
            _deckModel = new MockDeckModel();
            _handCard = new MockHandCardModel();
            var stateModel = new MockStateEventModel();
            _gameStartEventModel = stateModel;
            _drawCardCase = new DrawCardCase(_deckModel, _handCard, _gameStartEventModel, _gameStartEventModel);
        }

        [TearDown]
        public void TearDown()
        {
        }

        private DrawCardCase _drawCardCase;
        private MockDeckModel _deckModel;
        private MockHandCardModel _handCard;
        private MockStateEventModel _gameStartEventModel;

        [Test]
        public void DrawCardNumTest()
        {
            _deckModel.SetUpDeck(new List<Deck>(new []{Deck.SortedDeck(new (){Suit.Clubs, Suit.Diamonds}) }));
            var deckCardAmount = _deckModel.Decks.Count;
            
        }
    }
}