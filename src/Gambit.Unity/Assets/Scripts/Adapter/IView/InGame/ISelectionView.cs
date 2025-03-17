using System;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IView.InGame
{
    public interface IHandCardView
    {
        /// <summary>
        /// 手札が選択されたイベント
        /// </summary>
        public Action<PlayerCard> SelectionEvent { get; set; }
        public void TurnOn();
        public void TurnOff();
    }

    public interface ICursorOverrideEventView
    {
        public Action<PlayerCard> CursorOverrideEvent { get; set; }
        public Action<PlayerCard> CursorExitEvent { get; set; }
    }
}