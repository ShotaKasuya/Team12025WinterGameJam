using System;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class GameMainReceiverView : IGameMainReceiver
    {
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
        }
    }
}