using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Domain.UseCase.InGame;
using Gambit.Unity.Utility.Structure.InGame;
using NUnit.Framework;

namespace Gambit.Unity.Test.EditMode.Tests.EditModeTest.InGame
{
    public class AddPointTest
    {
        [SetUp]
        public void SetUp()
        {
            _mockPlayerCountModel = new MockPlayerCountModel();
            _mockResultModel = new MockResultModel();
            _mockScoreModel = new MockScoreModel(2);
            _mockConditionModel = new MockConditionModel(2);
            _addPointCase = new AddPointCase(_mockPlayerCountModel,_mockScoreModel,_mockResultModel,_mockConditionModel);
        }

        private AddPointCase _addPointCase;
        private MockScoreModel _mockScoreModel;
        private MockResultModel _mockResultModel;
        private MockPlayerCountModel _mockPlayerCountModel;
        private MockConditionModel _mockConditionModel;

        [TestCase(0,Rank.Ace,Rank.King)]
        [TestCase(0,Rank.King,Rank.Queen)]
        [TestCase(0,Rank.Ten,Rank.Nine)]
        [TestCase(0,Rank.Eight,Rank.Seven)]
        [TestCase(0,Rank.Six,Rank.Five)]
        [TestCase(0,Rank.Five,Rank.Four)]
        [TestCase(0,Rank.Three,Rank.Two)]
        //通常時の勝利の得点加算テスト
        public void AddPointWinTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {2,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(1,Rank.King,Rank.Ace)]
        [TestCase(1,Rank.Two,Rank.Three)]
        //通常時の負けの得点加算テスト
        public void AddPointLoseTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {0,2};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Jack,Rank.Nine)]
        [TestCase(0,Rank.Jack,Rank.Seven)]
        [TestCase(0,Rank.Jack,Rank.Five)]
        [TestCase(0,Rank.Jack,Rank.Four)]
        [TestCase(0,Rank.Jack,Rank.Two)]
        //Jの勝利の得点加算テスト
        public void AddPointWinJackTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {6,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Seven,Rank.Six)]
        [TestCase(0,Rank.Seven,Rank.Five)]
        [TestCase(0,Rank.Seven,Rank.Four)]
        [TestCase(0,Rank.Seven,Rank.Three)]
        [TestCase(0,Rank.Seven,Rank.Two)]
        //7の勝利の得点加算テスト
        public void AddPointWinSevenTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;

            int AddPoint=(int)winCard-(int)loseCard;

            int[] Result = {2*AddPoint,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Nine,Rank.Eight)]
        [TestCase(0,Rank.Nine,Rank.Seven)]
        [TestCase(0,Rank.Nine,Rank.Two)]
        //9の勝利の得点加算テスト
        public void AddPointWinNineTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {4,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }


        [TestCase(0,Rank.Ace,Rank.King)]
        [TestCase(0,Rank.King,Rank.Queen)]
        [TestCase(0,Rank.Ten,Rank.Nine)]
        [TestCase(0,Rank.Eight,Rank.Seven)]
        [TestCase(0,Rank.Six,Rank.Five)]
        [TestCase(0,Rank.Five,Rank.Four)]
        [TestCase(0,Rank.Three,Rank.Two)]
        //特殊無効時の勝利の得点加算テスト
        public void AddPointWinWeakTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Six);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {2,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Jack,Rank.Nine)]
        [TestCase(0,Rank.Jack,Rank.Seven)]
        [TestCase(0,Rank.Jack,Rank.Five)]
        [TestCase(0,Rank.Jack,Rank.Four)]
        [TestCase(0,Rank.Jack,Rank.Two)]
        //特殊無効時のJの勝利の得点加算テスト
        public void AddPointWinWeakJackTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Six);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {2,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Seven,Rank.Six)]
        [TestCase(0,Rank.Seven,Rank.Five)]
        [TestCase(0,Rank.Seven,Rank.Four)]
        [TestCase(0,Rank.Seven,Rank.Three)]
        [TestCase(0,Rank.Seven,Rank.Two)]
        //特殊無効時の7の勝利の得点加算テスト
        public void AddPointWinWeakSevenTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Six);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {2,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Nine,Rank.Eight)]
        [TestCase(0,Rank.Nine,Rank.Seven)]
        [TestCase(0,Rank.Nine,Rank.Two)]
        //特殊無効時の9の勝利の得点加算テスト
        public void AddPointWinWeakNineTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Six);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {2,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }


        [TestCase(0,Rank.Ace,Rank.King)]
        [TestCase(0,Rank.King,Rank.Queen)]
        [TestCase(0,Rank.Ten,Rank.Nine)]
        [TestCase(0,Rank.Eight,Rank.Seven)]
        [TestCase(0,Rank.Six,Rank.Five)]
        [TestCase(0,Rank.Five,Rank.Four)]
        [TestCase(0,Rank.Three,Rank.Two)]
        //弱体時の勝利の得点加算テスト
        public void AddPointWinHarfTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Ten);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {1,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Jack,Rank.Nine)]
        [TestCase(0,Rank.Jack,Rank.Seven)]
        [TestCase(0,Rank.Jack,Rank.Five)]
        [TestCase(0,Rank.Jack,Rank.Four)]
        [TestCase(0,Rank.Jack,Rank.Two)]
        //弱体時のJの勝利の得点加算テスト
        public void AddPointWinHarfJackTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Ten);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {3,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }


        [TestCase(0,Rank.Seven,Rank.Six)]
        [TestCase(0,Rank.Seven,Rank.Five)]
        [TestCase(0,Rank.Seven,Rank.Four)]
        [TestCase(0,Rank.Seven,Rank.Three)]
        [TestCase(0,Rank.Seven,Rank.Two)]
        //弱体時の7の勝利の得点加算テスト
        public void AddPointWinHarfSevenTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Ten);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;

            int AddPoint=(int)winCard-(int)loseCard;
            int[] Result = {AddPoint,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Nine,Rank.Eight)]
        [TestCase(0,Rank.Nine,Rank.Seven)]
        [TestCase(0,Rank.Nine,Rank.Two)]
        //弱体時の9の勝利の得点加算テスト
        public void AddPointWinHarfNineTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Ten);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {2,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }


        [TestCase(1,Rank.Jack,Rank.Ace)]
        [TestCase(1,Rank.Jack,Rank.King)]
        [TestCase(1,Rank.Jack,Rank.Queen)]
        //Jの負けの得点加算テスト
        public void AddPointLoseJackTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(0);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {-4,2};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }


        [TestCase(0,Rank.Ace,Rank.King)]
        [TestCase(0,Rank.King,Rank.Queen)]
        [TestCase(0,Rank.Ten,Rank.Nine)]
        [TestCase(0,Rank.Eight,Rank.Seven)]
        [TestCase(0,Rank.Six,Rank.Five)]
        [TestCase(0,Rank.Five,Rank.Four)]
        [TestCase(0,Rank.Three,Rank.Two)]
        //Draw2回時の勝利の得点加算テスト
        public void AddPointWinDrawTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(2);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {6,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Jack,Rank.Nine)]
        [TestCase(0,Rank.Jack,Rank.Seven)]
        [TestCase(0,Rank.Jack,Rank.Five)]
        [TestCase(0,Rank.Jack,Rank.Four)]
        [TestCase(0,Rank.Jack,Rank.Two)]
        //Draw2回時のJの勝利の得点加算テスト
        public void AddPointWinDrawJackTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(2);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {10,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Seven,Rank.Six)]
        [TestCase(0,Rank.Seven,Rank.Five)]
        [TestCase(0,Rank.Seven,Rank.Four)]
        [TestCase(0,Rank.Seven,Rank.Three)]
        [TestCase(0,Rank.Seven,Rank.Two)]
        //Draw2回時の7の勝利の得点加算テスト
        public void AddPointWinDrawSevenTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(2);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;

            int AddPoint=(int)winCard-(int)loseCard;

            int[] Result = {2*3*AddPoint,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }

        [TestCase(0,Rank.Nine,Rank.Eight)]
        [TestCase(0,Rank.Nine,Rank.Seven)]
        [TestCase(0,Rank.Nine,Rank.Two)]
        //Draw2回時の9の勝利の得点加算テスト
        public void AddPointWinDrawNineTest(int id,Rank winCard,Rank loseCard)
        {
            _mockConditionModel.SetCondition(id,Condition.Normal);
            var card = new List<Card> {new(Suit.Clubs,winCard),new(Suit.Clubs,loseCard)};
            var cards = new List<PlayerCard> {new(new PlayerId(0),card[0]),new(new PlayerId(1),card[1])};
            _mockPlayerCountModel.SetPlayerCount(2);
            var battleResult = BattleResult.Result(new PlayerId(id), cards);
            _mockResultModel.SetUpBattleResults(battleResult);
            _mockResultModel.SetUpLastResults(2);
            _addPointCase.AddPoint();
            var result = _mockScoreModel.Scores;


            int[] Result = {8,0};
            Assert.IsNotNull(result);
            Assert.AreEqual(Result,result);
        }
    }
}