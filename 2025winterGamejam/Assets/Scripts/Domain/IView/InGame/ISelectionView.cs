using System;
using Utility.Structure.InGame;

namespace Domain.IView.InGame
{
    public interface IHandCardView
    {
        /// <summary>
        /// 手札が選択されたイベント
        /// </summary>
        public Action<Card> SelectionEvent { get; set; }
        public void TurnOn();
        public void TurnOff();
        
    }
}