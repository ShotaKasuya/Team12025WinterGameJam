using UnityEngine;

namespace Gambit.Unity.Adapter.View.CardFactory
{
    public class GetPrefabAttribute : PropertyAttribute
    {
        public System.Type GetPrefabType { get; private set; }

        public GetPrefabAttribute(System.Type getPrefabType)
        {
            GetPrefabType = getPrefabType;
        }
    }
}
