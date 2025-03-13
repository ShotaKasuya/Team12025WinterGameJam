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

        public IReadOnlyList<Deck> DeckReader => Decks;
        public Deck[] Decks { get; }
    }
}