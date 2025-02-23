using System;
using System.Collections.Generic;
using Domain.IModel.Global;
using Domain.IModel.InGame.Judgement;
using Utility.Structure.InGame;

namespace Model.InGame.Judgement
{
    public class HandCardModel : IMutHandCardModel
    {
        public HandCardModel(IPlayerCountModel playerCountModel)
        {
            HandCards = new HandCard[playerCountModel.PlayerCount];
            for (int i = 0; i < playerCountModel.PlayerCount; i++)
            {
                HandCards[i] = new HandCard(new List<Card>());
            }
        }

        public IReadOnlyList<HandCard> HandCardReader => HandCards;

        public void StoreNewCard(int playerId, Card card)
        {
            HandCards[playerId].Cards.Add(card);
        }

        private HandCard[] HandCards { get; }
        public Action<PlayerHandCard> AddNewCardEvent { get; set; }
    }
}