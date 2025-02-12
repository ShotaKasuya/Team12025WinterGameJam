using System;

namespace Module.Option
{
    public readonly struct Option<T>
    {
        public static Option<T> Some(T value)
        {
            return new Option<T>(true, value);
        }

        public static Option<T> None()
        {
            return new Option<T>(false, default);
        }

        public bool IsSome { get; }
        public bool IsNone => !IsSome;
        private T Value { get; }

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
            IsSome = isSome;
            Value = value;
        }
    }
}