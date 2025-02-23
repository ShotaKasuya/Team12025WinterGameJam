using System;
using System.Collections.Generic;
using Domain.IModel.Global;
using Domain.IModel.InGame.Judgement;
using Utility.Structure.InGame;

namespace Model.InGame.Judgement
{
    public class HandCardModel: IMutHandCardModel
    {
        public HandCardModel(IPlayerCountModel playerCountModel)
        {
            HandCards = new List<HandCard>(playerCountModel.PlayerCount);
        }

        public IReadOnlyList<HandCard> HandCardReader => HandCards;
        public void StoreNewCard(int playerId, Card card)
        {
            HandCards[playerId].Cards.Add(card);
        }
        
        private List<HandCard> HandCards { get; }
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }
    }
}