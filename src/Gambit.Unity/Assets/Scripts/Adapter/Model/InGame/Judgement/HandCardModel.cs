using System;
using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.Model.InGame.Judgement
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