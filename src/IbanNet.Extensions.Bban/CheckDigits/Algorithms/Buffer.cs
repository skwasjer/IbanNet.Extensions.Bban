using System.Runtime.CompilerServices;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

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
        private init;
    }

    public override string ToString()
    {
        return new string(_value, 0, Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Buffer Create(char* value, int length)
    {
        return new Buffer(value, length);
    }
#endif

    public char this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _value[index];
    }
}
