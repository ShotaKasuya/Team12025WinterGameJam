using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.IView.InGame.CardFactory
{
    public interface ICardSprites
    {
        public Sprite CardBackSprite { get; }
        public Sprite GetCardSprite(Card card);
    }
}