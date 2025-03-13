using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IView.InGame
{
    /// <summary>
    /// ジャッジに向けて、選択されたカードが置かれる場所
    /// </summary>
    public interface ISelectedCardPoolView
    {
        public UniTask StoreNewCard(ProductCardView cardView);

        /// <summary>
        /// カードをすべて取り出す
        /// その際、内部で保持されているカードはすべて消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public IReadOnlyList<ProductCardView> PopAllCardViews();
    }
    
    /// <summary>
    /// 引き分けのカードを置く場所
    /// </summary>
    public interface IDrawCardPoolView
    {
        public UniTask StoreNewCard(ProductCardView cardView);

        /// <summary>
        /// カードをすべて取り出す
        /// その際、内部で保持されているカードはすべて消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public IReadOnlyList<ProductCardView> PopAllCardViews();
    }

    /// <summary>
    /// 勝ち取ったカードを置く場所
    /// </summary>
    public interface IWinCardPoolView
    {
        public UniTask StoreNewCard(ProductCardView cardView);

        /// <summary>
        /// カードをすべて取り出す
        /// その際、内部で保持されているカードはすべて消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public IReadOnlyList<ProductCardView> PopAllCardViews(PlayerId playerId);
    }

    /// <summary>
    /// 手札のカードを置く場所
    /// </summary>
    public interface IHandCardPoolView
    {
        public UniTask FixPosition();
        public UniTask StoreNewCard(ProductCardView cardView);
        public IReadOnlyList<ProductCardView> GetViewList(PlayerId playerId);

        /// <summary>
        /// 指定したカードを取り出す
        /// その際、内部で保持されているカードは消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public ProductCardView PopCardView(PlayerCard playerCard);
        
        public Action<ProductCardView> OnStore { get; set; }
        public Action<ProductCardView> OnPop { get; set; }
    }
}