using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.Model.InGame.Judgement
{
    public class DeckModel: IMutDeckModel
    {
        public DeckModel(IPlayerCountModel playerCountModel)
        {
            Decks = new Deck[playerCountModel.PlayerCount];
        }
        
        public Deck[] Decks { get; }
        public void DrawCards(Card[] buffer)
        {
            for (var i = 0; i < buffer.Length; i++)
            {
                buffer[i] = DeckReader[i].Cards.Pop();
            }
        }

        public IReadOnlyList<Deck> DeckReader => Decks;
        public bool IsRemain => DeckReader[0].Cards.Count != 0;
    }
}