using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Utility.Module.EnumList;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    [CreateAssetMenu(fileName = "ExplanationSprites", menuName = "ExplanationSpritesAsset", order = 0)]
    public class ExplanationSprites:ScriptableObject,IExplanationSprites
    {
        [SerializeField,EnumList(typeof(Rank))]
        private EnumArray<Sprite>  rankSprites;
        public Sprite GetImage(Card card)
        {
            var index = (int)card.Rank;
            return rankSprites.Get(index);
        }
    }
}