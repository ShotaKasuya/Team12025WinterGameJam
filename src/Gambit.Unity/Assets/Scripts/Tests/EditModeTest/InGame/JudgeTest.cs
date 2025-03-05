namespace Gambit.Unity.Test.EditMode.Tests.EditModeTest.InGame
{
    public class JudgeTest
    {
    //     [SetUp]
    //     public void SetUp()
    //     {
    //         _mockSelectionView = new MockSelectionView();
    //         _mockJudgeResultModel = new MockJudgeResultModel();
    //         _mockConditionModel = new MockConditionModel();
    //         _judgeCase = new CardJudgeCase(_mockSelectionView, _mockJudgeResultModel, _mockConditionModel);
    //     }
    //     
    //     [TearDown]
    //     public void TearDown()
    //     {
    //         _judgeCase.Dispose();
    //     }
    //     
    //     private CardJudgeCase _judgeCase;
    //     private MockSelectionView _mockSelectionView;
    //     private MockJudgeResultModel _mockJudgeResultModel;
    //     private MockConditionModel _mockConditionModel;
    //     
    //     [Test]
    //     public void ReturnDrawTest()
    //     {
    //         foreach (Rank rank in Enum.GetValues(typeof(Rank)))
    //         {
    //             var cards = new List<Card> { new(Suit.Clubs, rank), new(Suit.Clubs, rank) };
    //             _mockSelectionView.TriggerCardDecisionEvent(cards);
    //     
    //             var result = _mockJudgeResultModel.StoredResult;
    //             Assert.IsNotNull(result);
    //             Assert.AreEqual(BattleResult.Draw(cards), result);
    //         }
    //     }
    //     
    //     [TestCase(Rank.Three, Rank.Two)]
    //     [TestCase(Rank.Four, Rank.Three)]
    //     [TestCase(Rank.Six, Rank.Five)]
    //     [TestCase(Rank.Eight, Rank.Seven)]
    //     [TestCase(Rank.Ten, Rank.Nine)]
    //     [TestCase(Rank.Queen, Rank.Jack)]
    //     [TestCase(Rank.King, Rank.Queen)]
    //     public void NumberGreaterTest(Rank winCard, Rank loseCard)
    //     {
    //         var cards = new List<Card> { new(Suit.Clubs, winCard), new(Suit.Clubs, loseCard) };
    //         _mockSelectionView.TriggerCardDecisionEvent(cards);
    //     
    //         var result = _mockJudgeResultModel.StoredResult;
    //     
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(BattleResult.Result(new PlayerId(0), cards), result);
    //     }
    //     
    //     [Test]
    //     public void AceWinsOther()
    //     {
    //         var cards = new List<Card> { new(Suit.Clubs, Rank.Ace), new(Suit.Clubs, Rank.King) };
    //         _mockSelectionView.TriggerCardDecisionEvent(cards);
    //     
    //         var result = _mockJudgeResultModel.StoredResult;
    //     
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(BattleResult.Result(new PlayerId(0), cards), result);
    //     }
    //     
    //     [Test]
    //     public void TwoWinsAce()
    //     {
    //         var cards = new List<Card> { new(Suit.Clubs, Rank.Two), new(Suit.Clubs, Rank.Ace) };
    //         _mockSelectionView.TriggerCardDecisionEvent(cards);
    //     
    //         var result = _mockJudgeResultModel.StoredResult;
    //     
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(BattleResult.Result(new PlayerId(0), cards), result);
    //     }
    //     
    //     [TestCase(Rank.Three, Rank.Two)]
    //     [TestCase(Rank.Four, Rank.Three)]
    //     [TestCase(Rank.Six, Rank.Five)]
    //     [TestCase(Rank.Eight, Rank.Seven)]
    //     [TestCase(Rank.Ten, Rank.Nine)]
    //     [TestCase(Rank.Queen, Rank.Jack)]
    //     [TestCase(Rank.King, Rank.Queen)]
    //     public void DebuffTest(Rank winCard, Rank loseCard)
    //     {
    //         var cards = new List<Card> { new(Suit.Clubs, winCard), new(Suit.Clubs, loseCard) };
    //         _mockSelectionView.TriggerCardDecisionEvent(cards);
    //     
    //         var result = _mockJudgeResultModel.StoredResult;
    //     
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(BattleResult.Result(new PlayerId(0), cards), result);
    //     }
    //     
    //     [TestCase(Rank.Three, Rank.Two)]
    //     [TestCase(Rank.Four, Rank.Three)]
    //     [TestCase(Rank.Six, Rank.Five)]
    //     [TestCase(Rank.Eight, Rank.Seven)]
    //     [TestCase(Rank.Ten, Rank.Nine)]
    //     [TestCase(Rank.Queen, Rank.Jack)]
    //     [TestCase(Rank.King, Rank.Queen)]
    //     public void DebuffTest2(Rank winCard, Rank loseCard)
    //     {
    //         var cards = new List<Card> { new(Suit.Clubs, winCard), new(Suit.Clubs, loseCard) };
    //         _mockSelectionView.TriggerCardDecisionEvent(cards);
    //     
    //         var result = _mockJudgeResultModel.StoredResult;
    //     
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(BattleResult.Result(new PlayerId(0), cards), result);
    //     }
    }
}