using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Utility.Structure.InGame;

namespace Adapter.IView.InGame
{
    /// <summary>
    /// ジャッジに向けて、選択されたカードが置かれる場所
    /// </summary>
    public interface ISelectedCardPoolView
    {
        public UniTask StoreNewCard(NewProductCardView transformableView);

        /// <summary>
        /// カードをすべて取り出す
        /// その際、内部で保持されているカードはすべて消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public IReadOnlyList<NewProductCardView> PopAllCardViews(PlayerId playerId);
    }
    
    /// <summary>
    /// 引き分けのカードを置く場所
    /// </summary>
    public interface IDrawCardPoolView
    {
        public UniTask StoreNewCard(PlayerId playerId, NewProductCardView transformableView);

        /// <summary>
        /// カードをすべて取り出す
        /// その際、内部で保持されているカードはすべて消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public IReadOnlyList<NewProductCardView> PopAllCardViews(PlayerId playerId);
    }

    /// <summary>
    /// 勝ち取ったカードを置く場所
    /// </summary>
    public interface IWinCardPoolView
    {
        public UniTask StoreNewCard(PlayerId playerId, NewProductCardView transformableView);

        /// <summary>
        /// カードをすべて取り出す
        /// その際、内部で保持されているカードはすべて消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public IReadOnlyList<NewProductCardView> PopAllCardViews(PlayerId playerId);
    }

    /// <summary>
    /// 手札のカードを置く場所
    /// </summary>
    public interface IHandCardPoolView
    {
        public UniTask StoreNewCard(NewProductCardView transformableView);

        /// <summary>
        /// 指定したカードを取り出す
        /// その際、内部で保持されているカードは消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public NewProductCardView PopCardView(PlayerCard playerCard);
    }
}