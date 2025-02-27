using System.Collections.Generic;
using Adapter.IView.Utility;

namespace Adapter.IView.InGame
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