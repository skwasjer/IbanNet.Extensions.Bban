using System.Runtime.CompilerServices;

namespace IbanNet.Extensions.Bban.CheckDigits;

#if USE_SPANS
internal readonly ref struct Buffer
{
    private readonly ReadOnlySpan<char> _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Buffer(ReadOnlySpan<char> value)
    {
        _value = value;
    }

    public int Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _value.Length;
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Buffer Create(ReadOnlySpan<char> value)
    {
        return new Buffer(value);
    }

    public char this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _value[index];
    }
}
#else
internal readonly unsafe ref struct Buffer
{
    private readonly char* _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Buffer(char* value, int length)
    {
        _value = value;
        Length = length;
    }

    public int Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get;
    }

    public override string ToString()
    {
        return new string(_value, 0, Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Buffer Create(string? value)
    {
        value ??= string.Empty;
        fixed (char* ptr = value)
        {
            return new Buffer(ptr, value.Length);
        }
    }

    public char this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (index < 0 || index >= Length)
            {
                // Disabling warnings as this is the intended exception to throw in this case,
                // since we're accessing an indexer out of the bounds of the buffer.
                // We acknowledge that throwing IndexOutOfRangeException directly is generally discouraged,
                // but in this specific context, it is appropriate, esp. because (ReadOnly)Span<T> does the same,
                // and we want the buffer to behave similarly in all TFM's.
#pragma warning disable CA2201
#pragma warning disable S112
                throw new IndexOutOfRangeException();
#pragma warning restore S112
#pragma warning restore CA2201
            }

            return _value[index];
        }
    }
}
#endif
