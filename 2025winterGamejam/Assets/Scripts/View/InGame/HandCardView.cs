using IView.InGame;
using log4net.Filter;
using UnityEngine;

namespace View.InGame
{
    public class HandCardView : FactorableCardView
    {
        void OnMouseDown()
        {
            SelectionEvent.Invoke(Card);
        }
    }
}