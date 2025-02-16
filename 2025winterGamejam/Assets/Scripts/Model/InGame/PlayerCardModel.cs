using System;
using System.Collections.Generic;
using Domain.IModel.InGame;
using Structure.InGame;

namespace Model.InGame
{
    public class PlayerCardModel : IDeckModel, IMutHandCardModel, IHandCardEventModel
    {
        public List<Deck> Decks { get; } = new List<Deck>();
        public List<HandCard> HandCards { get; } = new List<HandCard>();
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }

        public void StoreNewCard(int playerId, Card card)
        {
            HandCards[playerId].Cards.Add(card);
            AddNewCardEvent?.Invoke(new PlayerHandCard(playerId, card));
        }
    }
}