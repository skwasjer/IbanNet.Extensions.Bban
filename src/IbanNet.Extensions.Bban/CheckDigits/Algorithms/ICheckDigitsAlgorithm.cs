namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

internal interface ICheckDigitsAlgorithm
{
    /// <summary>
    /// Returns the check digits for specified <paramref name="value" />.
    /// </summary>
    /// <param name="value">The input to compute check digits for.</param>
    /// <returns>The check digits or <c>-1</c> if invalid.</returns>
#if USE_SPANS
    public int Compute(ReadOnlySpan<char> value);
#else
    public int Compute(string value);
#endif
}
