using System;

namespace Gambit.Unity.Adapter.IView.OutGame.Title
{
    public interface IMatchConfPanelView
    {
        public Action OnStartGame { get; set; }
        public Action OnReturn { get; set; }
    }
}