using System;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Utility.Module.EnumList;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.CardFactory
{
    [CreateAssetMenu(fileName = "CardSprites", menuName = "CardSpritesAsset", order = 0)]
    public class CardSprites : ScriptableObject, ICardSprites
    {
        [SerializeField] private Sprite backSprite;

        [SerializeField, EnumList(typeof(Rank))]
        private EnumArray<Sprite> clubSprites;

        [SerializeField, EnumList(typeof(Rank))]
        private EnumArray<Sprite> spadeSprites;

        [SerializeField, EnumList(typeof(Rank))]
        private EnumArray<Sprite> heartSprites;

        [SerializeField, EnumList(typeof(Rank))]
        private EnumArray<Sprite> diamondSprites;

        public Sprite CardBackSprite => backSprite;

        public Sprite GetCardSprite(Card card)
        {
            var index = (int)card.Rank;
            return card.Suit switch
            {
                Suit.Clubs => clubSprites.Get(index),
                Suit.Spades => spadeSprites.Get(index),
                Suit.Hearts => heartSprites.Get(index),
                Suit.Diamonds => diamondSprites.Get(index),
                _ => throw new ArgumentException()
            };
        }
    }
}