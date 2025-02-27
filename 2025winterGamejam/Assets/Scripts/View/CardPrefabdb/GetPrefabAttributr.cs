using UnityEngine;

namespace View.CardPrefabdb
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
