using System.Runtime.CompilerServices;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

internal abstract class CheckDigitsAlgorithm : ICheckDigitsAlgorithm
{
#if USE_SPANS
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Compute(ReadOnlySpan<char> value)
    {
        return Compute(Buffer.Create(value));
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe int Compute(string value)
    {
        // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
        value ??= string.Empty;
        fixed (char* ptr = value)
        {
            return Compute(Buffer.Create(ptr, value.Length));
        }
    }
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected abstract int Compute(Buffer buffer);
}
