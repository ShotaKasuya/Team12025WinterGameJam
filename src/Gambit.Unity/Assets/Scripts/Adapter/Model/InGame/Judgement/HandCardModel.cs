using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.Model.InGame.Judgement
{
    public class HandCardModel : IMutHandCardModel
    {
        public HandCardModel(IPlayerCountModel playerCountModel)
        {
            HandCards = new HandCard[playerCountModel.PlayerCount];
            for (int i = 0; i < playerCountModel.PlayerCount; i++)
            {
                HandCards[i] = new HandCard(new List<PlayerCard>());
            }
        }

        public IReadOnlyList<HandCard> HandCardReader => HandCards;

        public void StoreNewCard(PlayerCard playerCard)
        {
            HandCards[playerCard.PlayerId.Id].Cards.Add(playerCard);
        }

        private HandCard[] HandCards { get; }
    }
}