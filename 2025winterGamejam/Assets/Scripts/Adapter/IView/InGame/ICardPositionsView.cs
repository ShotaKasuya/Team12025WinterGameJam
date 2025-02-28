using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.IView.InGame
{
    public interface ICardPositionsView
    {
        public IReadOnlyList<Pose> CardPositions { get; }
        public UniTask StoreNewCard(NewProductCardView productCardView);

        /// <summary>
        /// 指定したカードを取り出す
        /// その際、内部で保持されているカードは消える
        /// </summary>
        /// <returns>取り出されたカード</returns>
        public UniTask<NewProductCardView> PopCardView(Card playerCard);
    }
    
    public interface ICardGeneratePointView
    {
        public Pose GeneratePoint { get; }
    }
}