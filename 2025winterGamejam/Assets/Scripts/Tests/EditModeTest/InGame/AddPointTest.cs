using System.Collections.Generic;
using Domain.UseCase.InGame.Player;
using NUnit.Framework;
using Utility.Structure.InGame;

namespace Tests.EditModeTest.InGame
{
    // public class AddPointTest
    // {
    //     [SetUp]
    //     public void SetUp()
    //     {
    //         _mockJudgeEventModel = new MockJudgeEventModel();
    //         _mockPlayerIdModel = new MockPlayerIdModel();
    //         _mockPlayerScoreModel = new MockPlayerScoreModel();
    //         _mockConditionModel = new MockConditionModel[4];
    //         _addPointCase = new AddPointCase(_mockPlayerScoreModel,_mockPlayerIdModel,_mockJudgeEventModel,_mockConditionModel);
    //     }
    //     [TearDown]
    //     public void TearDown()
    //     {
    //         _addPointCase.Dispose();
    //     }
    //
    //     private AddPointCase _addPointCase;
    //     private MockPlayerScoreModel _mockPlayerScoreModel;
    //     private MockPlayerIdModel _mockPlayerIdModel;
    //     private MockJudgeEventModel _mockJudgeEventModel;
    //     private MockConditionModel[] _mockConditionModel;
    //
    //     [TestCase(0,Rank.Ace,Rank.King)]
    //     [TestCase(0,Rank.King,Rank.Queen)]
    //     [TestCase(0,Rank.Queen,Rank.Jack)]
    //     [TestCase(0,Rank.Ten,Rank.Nine)]
    //     [TestCase(0,Rank.Eight,Rank.Seven)]
    //     [TestCase(0,Rank.Six,Rank.Five)]
    //     [TestCase(0,Rank.Five,Rank.Four)]
    //     [TestCase(0,Rank.Three,Rank.Two)]
    //     //通常時の勝利の得点加算テスト
    //     public void AddPointWinTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel[id].SetCondition(,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(2,result);
    //     }
    //
    //     [TestCase(1,Rank.King,Rank.Ace)]
    //     [TestCase(1,Rank.Two,Rank.Three)]
    //     //通常時の負けの得点加算テスト
    //     public void AddPointLoseTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(0,result);
    //     }
    //
    //     [TestCase(0,Rank.Jack,Rank.Nine)]
    //     [TestCase(0,Rank.Jack,Rank.Seven)]
    //     [TestCase(0,Rank.Jack,Rank.Five)]
    //     [TestCase(0,Rank.Jack,Rank.Four)]
    //     [TestCase(0,Rank.Jack,Rank.Two)]
    //     //Jの勝利の得点加算テスト
    //     public void AddPointWinJackTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(6,result);
    //     }
    //
    //     [TestCase(0,Rank.Seven,Rank.Six)]
    //     [TestCase(0,Rank.Seven,Rank.Five)]
    //     [TestCase(0,Rank.Seven,Rank.Four)]
    //     [TestCase(0,Rank.Seven,Rank.Three)]
    //     [TestCase(0,Rank.Seven,Rank.Two)]
    //     //7の勝利の得点加算テスト
    //     public void AddPointWinSevenTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         int AddPoint=(int)winCard-(int)loseCard;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(2*AddPoint,result);
    //     }
    //
    //     [TestCase(0,Rank.Nine,Rank.Eight)]
    //     [TestCase(0,Rank.Nine,Rank.Seven)]
    //     [TestCase(0,Rank.Nine,Rank.Two)]
    //     //9の勝利の得点加算テスト
    //     public void AddPointWinNineTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(4,result);
    //     }
    //
    //
    //     [TestCase(0,Rank.Ace,Rank.King)]
    //     [TestCase(0,Rank.King,Rank.Queen)]
    //     [TestCase(0,Rank.Queen,Rank.Jack)]
    //     [TestCase(0,Rank.Ten,Rank.Nine)]
    //     [TestCase(0,Rank.Eight,Rank.Seven)]
    //     [TestCase(0,Rank.Six,Rank.Five)]
    //     [TestCase(0,Rank.Five,Rank.Four)]
    //     [TestCase(0,Rank.Three,Rank.Two)]
    //     //特殊無効時の勝利の得点加算テスト
    //     public void AddPointWininvalidTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Six);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(2,result);
    //     }
    //
    //     [TestCase(0,Rank.Jack,Rank.Nine)]
    //     [TestCase(0,Rank.Jack,Rank.Seven)]
    //     [TestCase(0,Rank.Jack,Rank.Five)]
    //     [TestCase(0,Rank.Jack,Rank.Four)]
    //     [TestCase(0,Rank.Jack,Rank.Two)]
    //     //特殊無効時のJの勝利の得点加算テスト
    //     public void AddPointWinJackinvalidTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Six);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(2,result);
    //     }
    //
    //     [TestCase(0,Rank.Seven,Rank.Six)]
    //     [TestCase(0,Rank.Seven,Rank.Five)]
    //     [TestCase(0,Rank.Seven,Rank.Four)]
    //     [TestCase(0,Rank.Seven,Rank.Three)]
    //     [TestCase(0,Rank.Seven,Rank.Two)]
    //     //特殊無効時の7の勝利の得点加算テスト
    //     public void AddPointWinSeveninvalidTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Six);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         int AddPoint=(int)winCard-(int)loseCard;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(2,result);
    //     }
    //
    //     [TestCase(0,Rank.Nine,Rank.Eight)]
    //     [TestCase(0,Rank.Nine,Rank.Seven)]
    //     [TestCase(0,Rank.Nine,Rank.Two)]
    //     //特殊無効時の9の勝利の得点加算テスト
    //     public void AddPointWinNineinvalidTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Six);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(2,result);
    //     }
    //
    //
    //     [TestCase(0,Rank.Ace,Rank.King)]
    //     [TestCase(0,Rank.King,Rank.Queen)]
    //     [TestCase(0,Rank.Queen,Rank.Jack)]
    //     [TestCase(0,Rank.Ten,Rank.Nine)]
    //     [TestCase(0,Rank.Eight,Rank.Seven)]
    //     [TestCase(0,Rank.Six,Rank.Five)]
    //     [TestCase(0,Rank.Five,Rank.Four)]
    //     [TestCase(0,Rank.Three,Rank.Two)]
    //     //弱体時の勝利の得点加算テスト
    //     public void AddPointWinWeekTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Ten);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(1,result);
    //     }
    //
    //     [TestCase(0,Rank.Jack,Rank.Nine)]
    //     [TestCase(0,Rank.Jack,Rank.Seven)]
    //     [TestCase(0,Rank.Jack,Rank.Five)]
    //     [TestCase(0,Rank.Jack,Rank.Four)]
    //     [TestCase(0,Rank.Jack,Rank.Two)]
    //     //弱体時のJの勝利の得点加算テスト
    //     public void AddPointWinJackWeekTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Ten);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(3,result);
    //     }
    //
    //     [TestCase(0,Rank.Seven,Rank.Six)]
    //     [TestCase(0,Rank.Seven,Rank.Five)]
    //     [TestCase(0,Rank.Seven,Rank.Four)]
    //     [TestCase(0,Rank.Seven,Rank.Three)]
    //     [TestCase(0,Rank.Seven,Rank.Two)]
    //     //弱体時の7の勝利の得点加算テスト
    //     public void AddPointWinSevenWeekTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Ten);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         int AddPoint=(int)winCard-(int)loseCard;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(AddPoint,result);
    //     }
    //
    //     [TestCase(0,Rank.Nine,Rank.Eight)]
    //     [TestCase(0,Rank.Nine,Rank.Seven)]
    //     [TestCase(0,Rank.Nine,Rank.Two)]
    //     //弱体時の9の勝利の得点加算テスト
    //     public void AddPointWinNineWeekTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Ten);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(2,result);
    //     }
    //
    //
    //     [TestCase(1,Rank.Jack,Rank.Ace)]
    //     [TestCase(1,Rank.Jack,Rank.King)]
    //     [TestCase(1,Rank.Jack,Rank.Queen)]
    //     //Jの負けの得点加算テスト
    //     public void AddPointLoseJackTest(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(0, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(-4,result);
    //     }
    //
    //
    //     [TestCase(0,Rank.Ace,Rank.King)]
    //     [TestCase(0,Rank.King,Rank.Queen)]
    //     [TestCase(0,Rank.Queen,Rank.Jack)]
    //     [TestCase(0,Rank.Ten,Rank.Nine)]
    //     [TestCase(0,Rank.Eight,Rank.Seven)]
    //     [TestCase(0,Rank.Six,Rank.Five)]
    //     [TestCase(0,Rank.Five,Rank.Four)]
    //     [TestCase(0,Rank.Three,Rank.Two)]
    //     //Draw2回時の勝利の得点加算テスト
    //     public void AddPointWinDarw2Test(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(2, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(6,result);
    //     }
    //
    //     [TestCase(0,Rank.Jack,Rank.Nine)]
    //     [TestCase(0,Rank.Jack,Rank.Seven)]
    //     [TestCase(0,Rank.Jack,Rank.Five)]
    //     [TestCase(0,Rank.Jack,Rank.Four)]
    //     [TestCase(0,Rank.Jack,Rank.Two)]
    //     //Draw2回時のJの勝利の得点加算テスト
    //     public void AddPointWinJackDraw2Test(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(2, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(10,result);
    //     }
    //
    //     [TestCase(0,Rank.Seven,Rank.Six)]
    //     [TestCase(0,Rank.Seven,Rank.Five)]
    //     [TestCase(0,Rank.Seven,Rank.Four)]
    //     [TestCase(0,Rank.Seven,Rank.Three)]
    //     [TestCase(0,Rank.Seven,Rank.Two)]
    //     //Draw2回時の7の勝利の得点加算テスト
    //     public void AddPointWinSevenDarw2Test(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(2, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         int AddPoint=(int)winCard-(int)loseCard;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(2*3*AddPoint,result);
    //     }
    //
    //     [TestCase(0,Rank.Nine,Rank.Eight)]
    //     [TestCase(0,Rank.Nine,Rank.Seven)]
    //     [TestCase(0,Rank.Nine,Rank.Two)]
    //     //Draw2回時の9の勝利の得点加算テスト
    //     public void AddPointWinNineDraw2Test(int id,Rank winCard,Rank loseCard)
    //     {
    //         var cards = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
    //         _mockConditionModel.SetCondition(id,Condition.Normal);
    //
    //         var battleResult = BattleResult.Result(new PlayerId(id), cards);
    //         var resultAndDrawCount = new ResultAndDrawCount(2, battleResult);
    //         _mockJudgeEventModel.InvokeJudgeEndEvent(resultAndDrawCount);
    //
    //         var result = _mockPlayerScoreModel.Addscore;
    //
    //         Assert.IsNotNull(result);
    //         Assert.AreEqual(8,result);
    //     }
    // }
}