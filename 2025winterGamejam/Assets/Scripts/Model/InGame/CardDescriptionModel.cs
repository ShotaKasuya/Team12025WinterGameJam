using Domain.IModel.InGame;
using UnityEngine;

namespace Model.InGame
{
    [CreateAssetMenu(fileName = "Description", menuName = "CardDescriptionModel", order = 0)]
    public class CardDescriptionModel : ScriptableObject
    {
        public string Description { get; }
        
        
    }
}