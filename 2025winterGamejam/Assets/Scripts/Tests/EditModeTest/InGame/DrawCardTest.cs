using Adapter.IModel.InGame;
using Adapter.IModel.InGame.Judgement;
using Adapter.IModel.InGame.Player;
using Domain.UseCase.InGame.Player;
using NUnit.Framework;

namespace Tests.EditModeTest.InGame
{
    public class DrawCardTest
    {
        [SetUp]
        public void SetUp()
        {
            _deckModel = new MockPlayerDeckModel();
            _handCard = new MockHandCardModelModel();
            var stateModel = new MockStateEventModel();
            _gameStartEventModel = stateModel;
            // _drawCardCase = new DrawCardCase(_deckModel, _handCard, _gameStartEventModel, _gameStartEventModel);
        }

        [TearDown]
        public void TearDown()
        {
        }

        private DrawCardCase _drawCardCase;
        private MockPlayerDeckModel _deckModel;
        private MockHandCardModelModel _handCard;
        private MockStateEventModel _gameStartEventModel;

        [Test]
        public void DrawCardNumTest()
        {
        }
    }
}