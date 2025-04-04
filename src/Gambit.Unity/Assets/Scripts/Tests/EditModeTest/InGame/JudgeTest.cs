using System;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Domain.UseCase.InGame;
using Gambit.Unity.Utility.Structure.InGame;
using NUnit.Framework;

namespace Gambit.Unity.Test.EditMode.Tests.EditModeTest.InGame
{
    public class JudgeTest
    {
        [SetUp]
        public void SetUp()
        {
            const int playerCount = 2;
            _mockSelectedCardModel = new MockSelectedCardModel(playerCount);
            _mockJudgeResultModel = new MockJudgeResultModel();
            _mockConditionModel = new MockConditionModel(playerCount);
            _judgeCase = new CardJudgeCase(_mockSelectedCardModel, _mockConditionModel, _mockJudgeResultModel);
        }

        private CardJudgeCase _judgeCase;

        private MockSelectedCardModel _mockSelectedCardModel;
        private MockJudgeResultModel _mockJudgeResultModel;
        private MockConditionModel _mockConditionModel;

        private BattleResult Judge(Card[] cards)
        {
            var playerCards = PlayerCard.MakeMockCards(cards);
            _mockSelectedCardModel.SetCards(playerCards);
            _judgeCase.Judge();

            return _mockJudgeResultModel.StoredResult;
        }

        [Test]
        public void ReturnDrawTest()
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                var cards = new Card[] { new(Suit.Clubs, rank), new(Suit.Clubs, rank) };

                var result = Judge(cards);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.IsDraw());
            }
        }

        [TestCase(Rank.Three, Rank.Two)]
        [TestCase(Rank.Four, Rank.Three)]
        [TestCase(Rank.Six, Rank.Five)]
        [TestCase(Rank.Eight, Rank.Seven)]
        [TestCase(Rank.Ten, Rank.Nine)]
        [TestCase(Rank.Queen, Rank.Jack)]
        [TestCase(Rank.King, Rank.Queen)]
        public void NumberGreaterTest(Rank winCard, Rank loseCard)
        {
            var cards = new Card[] { new(Suit.Clubs, winCard), new(Suit.Clubs, loseCard) };
            var result = Judge(cards);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsResult(out var winnerId));
            Assert.AreEqual(winnerId, new PlayerId(0));
        }

        [Test]
        public void AceWinsOther()
        {
            var cards = new Card[] { new(Suit.Clubs, Rank.Ace), new(Suit.Clubs, Rank.King) };
            var result = Judge(cards);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsResult(out var winnerId));
            Assert.AreEqual(winnerId, new PlayerId(0));
        }

        [Test]
        public void TwoWinsAce()
        {
            var cards = new Card[] { new(Suit.Clubs, Rank.Two), new(Suit.Clubs, Rank.Ace) };
            var result = Judge(cards);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsResult(out var winnerId));
            Assert.AreEqual(winnerId, new PlayerId(0));
        }

        [TestCase(Rank.Four, Rank.Three)]
        [TestCase(Rank.Six, Rank.Five)]
        [TestCase(Rank.Eight, Rank.Seven)]
        [TestCase(Rank.Ten, Rank.Nine)]
        [TestCase(Rank.Queen, Rank.Jack)]
        [TestCase(Rank.King, Rank.Queen)]
        public void DebuffTest(Rank winCard, Rank loseCard)
        {
            var cards = new Card[] { new(Suit.Clubs, winCard), new(Suit.Clubs, loseCard) };
            _mockConditionModel.SetCondition(0, Condition.Five);
            var result = Judge(cards);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsResult(out var winnerId));
            Assert.AreEqual(winnerId, new PlayerId(1));
        }

        [TestCase(Rank.Three, Rank.Two)]
        [TestCase(Rank.Four, Rank.Three)]
        [TestCase(Rank.Six, Rank.Five)]
        [TestCase(Rank.Eight, Rank.Seven)]
        [TestCase(Rank.Ten, Rank.Nine)]
        [TestCase(Rank.Queen, Rank.Jack)]
        [TestCase(Rank.King, Rank.Queen)]
        public void DebuffTest2(Rank winCard, Rank loseCard)
        {
            var cards = new Card[] { new(Suit.Clubs, winCard), new(Suit.Clubs, loseCard) };
            var result = Judge(cards);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsResult(out var winnerId));
            Assert.AreEqual(winnerId, new PlayerId(0));
        }
    }
}