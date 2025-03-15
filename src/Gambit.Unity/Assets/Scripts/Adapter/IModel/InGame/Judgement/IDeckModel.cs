using System.Collections.Generic;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Judgement
{
    /// <summary>
    /// 各プレイヤーのデッキ
    /// </summary>
    public interface IMutDeckModel: IDeckModel
    {
        public Deck[] Decks { get; }
        public void DrawCards(Card[] buffer);
    }
    
    public interface IDeckModel
    {
        public IReadOnlyList<Deck> DeckReader { get; }
        public bool IsRemain { get; }
    }

    public class MockDeckModel : IMutDeckModel
    {
        public Deck[] Decks { get; private set; }

        public bool IsRemain => DeckReader[0].Cards.Count == 0;
        public IReadOnlyList<Deck> DeckReader => Decks;

        public void SetUpDeck(Deck[] decks)
        {
            Decks = decks;
        }

        public void DrawCards(Card[] buffer)
        {
            throw new System.NotImplementedException();
        }
    }
}