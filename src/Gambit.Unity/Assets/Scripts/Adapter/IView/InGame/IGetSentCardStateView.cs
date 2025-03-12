using System;
using Gambit.Unity.Structure.Utility.InGame;

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