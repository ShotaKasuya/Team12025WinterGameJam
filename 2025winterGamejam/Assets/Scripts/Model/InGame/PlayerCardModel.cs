using System;
using System.Collections.Generic;
using Domain.IModel.InGame;
using Utility.Structure.InGame;

namespace Model.InGame
{
    public class PlayerCardModel : IDeckModel, IMutHandCardModel, IHandCardEventModel
    {
        public List<Deck> Decks { get; } = new List<Deck>();
        public IReadOnlyList<HandCard> HandCards { get; } = new List<HandCard>();
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }

        public void StoreNewCard(int playerId, Card card)
        {
            HandCards[playerId].Cards.Add(card);
        }
    }
}