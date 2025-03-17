using System;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IView.InGame
{
    public interface IGetSentCardStateView
    {
        Action<PlayerCard> GetSentCard { get; set; }
    }

    public interface IMatchEventView
    {
        public Action OnMatched { get; set; }
    }
}