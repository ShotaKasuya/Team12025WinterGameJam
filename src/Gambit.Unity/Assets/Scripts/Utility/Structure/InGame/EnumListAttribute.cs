using UnityEngine;
namespace Utility.Structure.InGame

{    public class EnumListAttribute : PropertyAttribute
    {
        public System.Type EnumType { get; private set; }

        public EnumListAttribute(System.Type enumType)
        {
            EnumType = enumType;
        }
    }
}