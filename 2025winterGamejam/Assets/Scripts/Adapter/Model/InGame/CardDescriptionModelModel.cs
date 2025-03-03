using System;
using Adapter.IModel.InGame;
using UnityEngine;
using UnityEngine.UI;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame
{
    [CreateAssetMenu(fileName = "Description", menuName = "CardDescriptionModel", order = 0)]
    public class CardDescriptionModelModel : ScriptableObject, ICardDescriptionModel
    {
        [SerializeField] [EnumList(typeof(Rank))]
        private Image[] descriptions = new Image[Enum.GetValues(typeof(Rank)).Length];
        
        public Image Description(Card card)
        {
            return descriptions[(int)card.Rank];
        }
    }
}