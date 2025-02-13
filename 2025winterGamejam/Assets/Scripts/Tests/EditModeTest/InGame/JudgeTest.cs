using System;
using System.Collections.Generic;
using Domain.IModel.InGame;
using Domain.IView.InGame;
using Domain.UseCase.InGame;
using NUnit.Framework;
using Structure.InGame;

namespace Tests.EditModeTest.InGame
{
    public class JudgeTest
    {
        [SetUp]
        public void SetUp()
        {
            _mockDecisionView = new MockDecisionView();
            _mockJudgeResultModel = new MockJudgeResultModel();
            _judgeCase = new CardJudgeCase(_mockDecisionView, _mockJudgeResultModel);
        }

        [TearDown]
        public void TearDown()
        {
            _judgeCase.Dispose();
        }

        private CardJudgeCase _judgeCase;
        private MockDecisionView _mockDecisionView;
        private MockJudgeResultModel _mockJudgeResultModel;

        [Test]
        public void ReturnDrawTest()
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                var cards = new List<Card> { new(Suit.Clubs, rank), new(Suit.Clubs, rank) };
                _mockDecisionView.TriggerCardDecisionEvent(cards);

                var result = _mockJudgeResultModel.StoredResult;
                Assert.IsNotNull(result);
                Assert.AreEqual(BattleResult.Draw(cards), result);
            }
        }

        [TestCase(Rank.Two, Rank.Ace)]
        [TestCase(Rank.Four, Rank.Three)]
        [TestCase(Rank.Six, Rank.Five)]
        [TestCase(Rank.Eight, Rank.Seven)]
        [TestCase(Rank.Ten, Rank.Nine)]
        [TestCase(Rank.Queen, Rank.Jack)]
        [TestCase(Rank.King, Rank.Queen)]
        public void NumberGreaterTest(Rank winCard, Rank loseCard)
        {
            var cards = new List<Card> { new(Suit.Clubs, winCard), new(Suit.Clubs, loseCard) };
            _mockDecisionView.TriggerCardDecisionEvent(cards);

            var result = _mockJudgeResultModel.StoredResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(BattleResult.Result(0, cards), result);
        }
    }
}