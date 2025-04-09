using System;
using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.Model.InGame.Judgement
{
    public class DeckModel: IMutDeckModel, IDeckChangeEventModel
    {
        public DeckModel(IPlayerCountModel playerCountModel)
        {
            Decks = new Deck[playerCountModel.PlayerCount];
        }
        
        public Deck[] Decks { get; }
        public void DrawCards(PlayerCard[] buffer)
        {
            for (var i = 0; i < buffer.Length; i++)
            {
                var card = DeckReader[i].Pop();
                var context = new IDeckChangeEventModel.Context(card.PlayerId, DeckReader[i].Cards.Count);
                
                buffer[i] = card;
                OnChange?.Invoke(context);
            }
        }

        public IReadOnlyList<Deck> DeckReader => Decks;
        public bool IsRemain => DeckReader[0].Cards.Count != 0;
        public Action<IDeckChangeEventModel.Context> OnChange { get; set; }
    }
}