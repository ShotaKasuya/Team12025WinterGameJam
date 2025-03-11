using System;
using Gambit.Unity.Structure.Utility.InGame;
using Gambit.Unity.Structure.Utility.InGame.StateMachine;
using Unity.Plastic.Antlr3.Runtime.Misc;

namespace Gambit.Unity.Adapter.IView.InGame
{
    public interface IGetSentCardStateView
    {
        Action<PlayerCard> GetSentCard { get; set; }
    }
}