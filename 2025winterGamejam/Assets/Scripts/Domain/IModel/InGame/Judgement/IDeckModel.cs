using System.Collections.Generic;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame.Judgement
{
    /// <summary>
    /// 各プレイヤーのデッキ
    /// </summary>
    public interface IMutDeckModel: IDeckModel
    {
        public List<Deck> Decks { get; }
    }
    
    public interface IDeckModel
    {
        public IReadOnlyList<Deck> DeckReader { get; }
    }

    public class MockDeckModel : IMutDeckModel
    {
        public List<Deck> Decks { get; private set; } = new List<Deck>();
        public IReadOnlyList<Deck> DeckReader => Decks;

        public void SetUpDeck(List<Deck> decks)
        {
            Decks = decks;
        }

    }
}