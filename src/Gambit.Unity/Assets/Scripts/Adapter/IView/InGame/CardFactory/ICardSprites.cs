using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.IView.InGame
{
    public interface ICardSprites
    {
        public Sprite CardBackSprite { get; }
        public Sprite GetCardSprite(Card card);
    }
}