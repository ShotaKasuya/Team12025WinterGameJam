using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.IView.InGame
{
    public interface ICardPositionsView
    {
        public IReadOnlyList<Pose> CardPositions { get; }
        public void StoreNewCard(ProductCardView productCardView);

        /// <summary>
        /// 指定したカードを取り出す
        /// その際、内部で保持されているカードは消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public ProductCardView PopCardView(Card playerCard);
        public UniTask FixPosition();
    }
}