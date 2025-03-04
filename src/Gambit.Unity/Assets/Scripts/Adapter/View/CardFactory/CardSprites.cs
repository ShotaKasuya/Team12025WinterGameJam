using System;
using Adapter.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.CardPrefabdb
{
    [CreateAssetMenu(fileName = "CardSprites", menuName = "CardSpritesAsset", order = 0)]
    public class CardSprites : ScriptableObject, ICardSprites
    {
        [SerializeField] private Sprite backSprite;

        [SerializeField, EnumList(typeof(Rank))]
        private Sprite[] clubSprites;

        [SerializeField, EnumList(typeof(Rank))]
        private Sprite[] spadeSprites = new Sprite[Enum.GetValues(typeof(Rank)).Length];

        [SerializeField, EnumList(typeof(Rank))]
        private Sprite[] heartSprites = new Sprite[Enum.GetValues(typeof(Rank)).Length];

        [SerializeField, EnumList(typeof(Rank))]
        private Sprite[] diamondSprites = new Sprite[Enum.GetValues(typeof(Rank)).Length];

        public Sprite CardBackSprite => backSprite;

        public Sprite GetCardSprite(Card card)
        {
            var index = (int)card.Rank;
            return card.Suit switch
            {
                Suit.Clubs => clubSprites[index],
                Suit.Spades => spadeSprites[index],
                Suit.Hearts => heartSprites[index],
                Suit.Diamonds => diamondSprites[index],
                _ => throw new ArgumentException()
            };
        }
    }
}