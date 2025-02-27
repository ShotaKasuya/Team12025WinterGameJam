using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Domain.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;


namespace View.CardPrefabdb
{
    [CreateAssetMenu(fileName = "GetPrefab",menuName = "GetPrefab",order =0)]
    public class GetPrefab : ScriptableObject , IGetPrefab
    {
        [SerializeField][GetPrefab(typeof(Rank))] private MyList clubs;
        [SerializeField][GetPrefab(typeof(Rank))] private MyList spades;
        [SerializeField][GetPrefab(typeof(Rank))] private MyList hearts;
        [SerializeField][GetPrefab(typeof(Rank))] private MyList diamonds;

        [Serializable]
        public class MyList
        {
            [SerializeField] public ProductCardView[] number = new ProductCardView[Enum.GetValues(typeof(Rank)).Length];
        }
        public ProductCardView GetProductCardView(Card card)
        {
            switch(card.Suit)
            {
                case Suit.Clubs:
                return clubs.number[(int)card.Rank];
                case Suit.Spades:
                return spades.number[(int)card.Rank];
                case Suit.Hearts:
                return hearts.number[(int)card.Rank];
                case Suit.Diamonds:
                return diamonds.number[(int)card.Rank];
                default:
                return null;
            }
        }
    }
}