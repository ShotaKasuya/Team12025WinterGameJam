using System;
using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Utility.Module.EnumList;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.Model.InGame
{
    [CreateAssetMenu(fileName = "Description", menuName = "CardDescriptionModel", order = 0)]
    public class CardDescriptionModel : ScriptableObject, ICardDescriptionModel
    {
        [SerializeField] [EnumList(typeof(Rank))]
        private Image[] descriptions = new Image[Enum.GetValues(typeof(Rank)).Length];
        
        public Image Description(Card card)
        {
            return descriptions[(int)card.Rank];
        }
    }
}