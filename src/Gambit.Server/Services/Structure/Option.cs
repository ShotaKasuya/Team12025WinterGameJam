namespace Gambit.Server.Services.Structure;

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

    public readonly bool IsSome;
    private readonly T? _value;

    public bool TryGetValue(out T value)
    {
        var result = false;
        if (IsSome)
        {
            value = _value;
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

        return _value;
    }

    private Option(bool isSome, T value)
    {
        IsSome = isSome;
        _value = value;
    }

    public override string ToString()
    {
        return IsSome ? $"Some({_value})" : "None";
    }
}