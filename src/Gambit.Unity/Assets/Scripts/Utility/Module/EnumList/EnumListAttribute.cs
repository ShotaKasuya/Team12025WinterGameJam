using System;
using UnityEngine;

namespace Gambit.Unity.Utility.Module.EnumList
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

        public T Get(int index)
        {
            return array[index];
        }
    }
}