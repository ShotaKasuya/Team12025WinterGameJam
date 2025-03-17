using System;
using UnityEngine;

namespace Gambit.Unity.Utility.Module.Option
{
    [Serializable]
    public struct Option<T>
    {
        public static Option<T> Some(T value)
        {
            return new Option<T>(true, value);
        }

        public static Option<T> None()
        {
            return new Option<T>(false, default);
        }

        [SerializeField] private bool innerIsSome;
        [SerializeField] private T innerValue;
        public bool IsSome => innerIsSome;
        public bool IsNone => !innerIsSome;
        private T Value => innerValue;

        public bool TryGetValue(out T value)
        {
            var result = false;
            if (IsSome)
            {
                value = Value;
                result = true;
            }
            else
            {
                value = default;
            }

            return result;
        }

        public T Unwrap()
        {
            if (!IsSome)
            {
                throw new Exception("unwrap none value");
            }

            return Value;
        }

        private Option(bool isSome, T value)
        {
            innerIsSome = isSome;
            innerValue = value;
        }

        public override string ToString()
        {
            return IsSome ? $"Some({Value})" : "None";
        }
    }
}