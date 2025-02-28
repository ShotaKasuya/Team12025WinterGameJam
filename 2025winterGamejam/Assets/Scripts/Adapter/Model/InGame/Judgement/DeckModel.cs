using System.Collections.Generic;
using Adapter.IModel.Global;
using Adapter.IModel.InGame.Judgement;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame.Judgement
{
    public class DeckModel: IMutDeckModel
    {
        public DeckModel(IPlayerCountModel playerCountModel)
        {
            Decks = new Deck[playerCountModel.PlayerCount];
        }

        public IReadOnlyList<Deck> DeckReader => Decks;
        public Deck[] Decks { get; }
    }
}