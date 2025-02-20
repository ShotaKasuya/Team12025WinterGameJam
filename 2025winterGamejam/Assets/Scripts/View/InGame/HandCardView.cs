using IView.InGame;

namespace View.InGame
{
    public class HandCardView : FactorableCardView
    {
        private void OnMouseDown()
        {
            SelectionEvent?.Invoke(Card);
        }
    }
}