using System;
using UnityEngine;

namespace Gambit.Unity.Structure.Utility.InGame

{
    public class EnumListAttribute : PropertyAttribute
    {
        public Type EnumType { get; private set; }

        public EnumListAttribute(Type enumType)
        {
            EnumType = enumType;
        }
    }

    [Serializable]
    public class EnumArray<T>
    {
        [SerializeField] private T[] array;
        public T[] Array => array;
    }
}