using System;
using Adapter.IModel.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame
{
    [CreateAssetMenu(fileName = "Description", menuName = "CardDescriptionModel", order = 0)]
    public class CardDescriptionModel : ScriptableObject, ICardDescription
    {
        [SerializeField]
        [EnumList(typeof(Rank))]
        private MyList hoge;

        public bool a;
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