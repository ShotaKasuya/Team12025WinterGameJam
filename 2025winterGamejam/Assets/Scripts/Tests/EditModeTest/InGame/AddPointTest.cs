using System.IO.Pipes;
using System.Collections.Generic;
using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using Domain.UseCase.InGame;
using Domain.UseCase.InGame.Player;
using Model.InGame;
using NUnit.Framework;
using Utility.Structure.InGame;

namespace Tests.EditModeTest.InGame
{
    public class AddPointTest
    {
        [SetUp]
        public void SetUp()
        {
            _mockJudgeEventModel = new MockJudgeEventModel();
            _mockPlayerIdModel = new MockPlayerIdModel();
            _mockScoreModelPlayer = new MockScoreModelPlayer();
            _mockConditionModel = new MockConditionModel();
            _addPointCase = new AddPointCase(_mockScoreModelPlayer,_mockPlayerIdModel,_mockJudgeEventModel,_mockConditionModel);
        }
        [TearDown]
        public void TearDown()
        {
            _addPointCase.Dispose();
        }

        private AddPointCase _addPointCase;
        private MockScoreModelPlayer _mockScoreModelPlayer;
        private MockPlayerIdModel _mockPlayerIdModel;
        private MockJudgeEventModel _mockJudgeEventModel;
        private MockConditionModel _mockConditionModel;

        [TestCase(0,Rank.Ace,Rank.King)]
        public void AddPointWinTest(int id,Rank winCard,Rank loseCard)
        {
            var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            _mockPlayerIdModel.SetUpId(PlayerId.StorePlayerId(id));
            _mockConditionModel.SetCondition(id,Condition.Normal);

            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
            _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);

            var result = _mockScoreModelPlayer.addscore;

            Assert.IsNotNull(result);
            Assert.AreEqual(2,result);
        }
    }
}