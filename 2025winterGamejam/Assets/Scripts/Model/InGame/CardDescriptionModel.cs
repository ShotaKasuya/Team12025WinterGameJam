using System;
using System.Collections.Generic;
using Domain.IModel.InGame;
using UnityEditor.UI;
using UnityEngine;
using Utility.Structure.InGame;

namespace Model.InGame
{
    [CreateAssetMenu(fileName = "Description", menuName = "CardDescriptionModel", order = 0)]
    public class CardDescriptionModel : ScriptableObject, ICardDescription
    {
        [SerializeField]
        private MyList hoge;

        string ICardDescription.EffectName(Card card)
        {
            return hoge.effectName[(int)card.Rank];
        }

        string ICardDescription.Description(Card card)
        {
            return hoge.description[(int)card.Rank];
        }

        [Serializable]
        public class MyList
        {
            [SerializeField] public string[] description = new string[Enum.GetValues(typeof(Rank)).Length];
            [SerializeField] public string[] effectName = new string[Enum.GetValues(typeof(Rank)).Length];
        }
    }
}