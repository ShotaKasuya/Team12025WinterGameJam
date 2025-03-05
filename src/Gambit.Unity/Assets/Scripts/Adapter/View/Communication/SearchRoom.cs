using System;
using Gambit.Shared;

namespace Gambit.Unity.Adapter.View.Communication
{
    
    public class SearchRoomReceiver : ISearchRoomReceiver
    {
        public void Join(string userName)
        {
            Console.WriteLine($"{userName} joined");
        }

        public void MatchResult(string machResult)
        {
            Console.WriteLine($" VS {machResult}");
        }
    }
}