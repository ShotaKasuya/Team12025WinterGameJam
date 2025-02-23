using System.Collections.Generic;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame.Judgement
{
    /// <summary>
    /// 各プレイヤーのデッキ
    /// </summary>
    public interface IMutDeckModel: IDeckModel
    {
        public Deck[] Decks { get; }
    }
    
    public interface IDeckModel
    {
        public IReadOnlyList<Deck> DeckReader { get; }
    }

    public class MockDeckModel : IMutDeckModel
    {
        public Deck[] Decks { get; private set; }
        public IReadOnlyList<Deck> DeckReader => Decks;

        public void SetUpDeck(Deck[] decks)
        {
            Decks = decks;
        }

    }
}