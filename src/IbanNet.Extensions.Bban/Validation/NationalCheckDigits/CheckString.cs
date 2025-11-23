namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// A delegate to extract the string used to calculate the check digit(s) of a BBAN.
/// </summary>
#if USE_SPANS
internal delegate ReadOnlySpan<char> CheckString(ReadOnlySpan<char> bban);
#else
internal delegate string CheckString(string bban);
#endif

internal static class CheckStringExtensions
{
    extension(CheckString)
    {
        /// <summary>
        /// Gets the check string at a fixed known position.
        /// </summary>
        internal static CheckString At(int startIndex)
        {
#if USE_SPANS
            return bban => bban.Slice(startIndex);
#else
            return bban => bban.Substring(startIndex);
#endif
        }

        /// <summary>
        /// Gets the check string at a fixed known position.
        /// </summary>
        internal static CheckString At(int startIndex, int length)
        {
#if USE_SPANS
            return bban => bban.Slice(startIndex, length);
#else
            return bban => bban.Substring(startIndex, length);
#endif
        }
    }
}
