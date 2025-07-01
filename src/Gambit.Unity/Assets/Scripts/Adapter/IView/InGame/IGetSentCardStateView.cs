using System;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IView.InGame
{
    public interface IGetSentCardStateView
    {
        public Action<PlayerCard> GetSentCard { get; set; }
    }

    public interface IGetDeclarationView
    {
        public Action<PlayerId, Rank> OtherPlayerDeclaration { get; set; }
    }

    public interface IMatchEventView
    {
        public Action OnMatched { get; set; }
    }
}