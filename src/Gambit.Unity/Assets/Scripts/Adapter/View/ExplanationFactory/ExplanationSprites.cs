using Gambit.Unity.Adapter.IView.InGame.IExplanationFactory;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.ExplanationFactory
{
    [CreateAssetMenu(fileName = "ExplanationSprites", menuName = "ExplanationSpritesAsset", order = 0)]
    public class ExplanationSprites:ScriptableObject,IExplanationSprites
    {
        [SerializeField,EnumList(typeof(Rank))]
        private EnumArray<Sprite>  rankSprites;
        public Sprite GetImage(Card card)
        {
            var index = (int)card.Rank;
            return rankSprites.Array[index];
        }
    }
}