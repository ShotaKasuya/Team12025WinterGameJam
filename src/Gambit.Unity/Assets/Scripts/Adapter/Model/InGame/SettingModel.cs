using Gambit.Unity.Adapter.IModel.InGame.Setting;
using UnityEngine;

namespace Gambit.Unity.Adapter.Model.InGame
{
    [CreateAssetMenu(menuName = "SettingModel", fileName = "GameSetting")]
    public class SettingModel: ScriptableObject, IHandCardSettingModel
    {
        [SerializeField] private int initHandCard;

        public int InitHandCard => initHandCard;
    }
}