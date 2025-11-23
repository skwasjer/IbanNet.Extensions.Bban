using System.Globalization;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// A delegate to extract the check digit(s) from a BBAN.
/// </summary>
#if USE_SPANS
internal delegate int CheckDigits(ReadOnlySpan<char> bban);
#else
internal delegate int CheckDigits(string bban);
#endif

internal static class CheckDigitsExtensions
{
    extension(CheckDigits)
    {
        /// <summary>
        /// Gets the check digit(s) at a fixed known position.
        /// </summary>
        internal static CheckDigits At(int startIndex, int length)
        {
            return bban => int.Parse(
#if USE_SPANS
                bban.Slice(startIndex, length),
#else
                bban.Substring(startIndex, length),
#endif
                provider: CultureInfo.InvariantCulture);
        }
    }
}
