namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

internal interface ICheckDigitsAlgorithm
{
    /// <summary>
    /// Returns the check digits for specified <paramref name="value" />.
    /// </summary>
    /// <param name="value">The input buffer to compute check digits for.</param>
    /// <returns>The check digits or <c>-1</c> if invalid.</returns>
    public int Compute(char[] value);
}
