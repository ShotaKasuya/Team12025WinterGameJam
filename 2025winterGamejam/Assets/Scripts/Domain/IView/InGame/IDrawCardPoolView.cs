using System.Collections.Generic;
using Domain.IView.Utility;

namespace Domain.IView.InGame
{
    /// <summary>
    /// 引き分けのカードを置く場所
    /// </summary>
    public interface IDrawCardPoolView
    {
        public void StoreNewCard(ITransformableView transformableView);
        public IReadOnlyList<ITransformableView> PopCardViews();
    }
}