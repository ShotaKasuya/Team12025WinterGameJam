using System;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using Gambit.Unity.Structure.Utility.InGame;
using Gambit.Unity.Adapter.IView.InGame;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class GameMainReceiverView : IGameMainReceiver,IGetSentCardStateView
    {
        public Action<PlayerCard> GetSentCard { get; set; }
        
        public void OnJoin(string userName)
        {
            Console.WriteLine($"{userName} joined");
        }

        public void MatchResult(string machResult)
        {
            Console.WriteLine($" VS {machResult}");
        }

        public void SendSelectedCard(PlayerCardTransferObject playerCardTransferObject)
        {
            // todo
            var playerCard = PlayerCard.ConversionSentPlayerCard(playerCardTransferObject);
            InvokeGetSentCardState(playerCard);
        }

        private void InvokeGetSentCardState(PlayerCard playerCard)
        {
            GetSentCard.Invoke(playerCard);
        }
    }
}