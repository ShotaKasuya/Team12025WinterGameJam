using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.IView.InGame.Ui
{
    /// <summary>
    /// カード効果の説明を行う画像を取得できる
    /// </summary>
    public interface IExplanationSprites
    {
        public Sprite GetImage(Card  card);
    }
}