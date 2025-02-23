using System.Collections.Generic;
using Domain.IModel.Global;
using Domain.IModel.InGame.Judgement;
using Utility.Structure.InGame;

namespace Model.InGame.Judgement
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