using Adapter.IModel.InGame.Setting;
using UnityEngine;

namespace Adapter.Model.InGame
{
    [CreateAssetMenu(menuName = "SettingModel", fileName = "GameSetting")]
    public class SettingModel: ScriptableObject, IHandCardSettingModel
    {
        [SerializeField] private int initHandCard;

        public int InitHandCard => initHandCard;
    }
}