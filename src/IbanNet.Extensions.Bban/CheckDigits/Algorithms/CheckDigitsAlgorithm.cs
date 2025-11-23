using System.Runtime.CompilerServices;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

internal abstract class CheckDigitsAlgorithm : ICheckDigitsAlgorithm
{
#if USE_SPANS
    public int Compute(ReadOnlySpan<char> value)
    {
#else
    public int Compute(string value)
    {
#endif
        return Compute(Buffer.Create(value));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected abstract int Compute(Buffer buffer);
}
