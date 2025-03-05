using System;
using Gambit.Unity.Structure.Utility.InGame;

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
}