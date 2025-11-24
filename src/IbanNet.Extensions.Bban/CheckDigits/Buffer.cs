using System.Runtime.CompilerServices;

namespace IbanNet.Extensions.Bban.CheckDigits;

internal readonly ref struct Buffer
{
#if USE_SPANS
    private readonly ReadOnlySpan<char> _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Buffer(ReadOnlySpan<char> value)
    {
        _value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Buffer Create(ReadOnlySpan<char> value)
    {
        return new Buffer(value);
    }
#else
    private readonly string _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Buffer(string value)
    {
        _value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Buffer Create(string? value)
    {
        value ??= string.Empty;
        return new Buffer(value);
    }
#endif

    public int Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _value.Length;
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    public char this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _value[index];
    }
}
