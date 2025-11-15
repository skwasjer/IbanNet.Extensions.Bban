namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// A delegate to extract the string used to calculate the check digit(s) of a BBAN.
/// </summary>
internal delegate string CheckString(string bban);

internal static class CheckStringExtensions
{
    extension(CheckString)
    {
        /// <summary>
        /// Gets the check string at a fixed known position.
        /// </summary>
        internal static CheckString At(int startIndex)
        {
            return bban => bban.Substring(startIndex);
        }

        /// <summary>
        /// Gets the check string at a fixed known position.
        /// </summary>
        internal static CheckString At(int startIndex, int length)
        {
            return bban => bban.Substring(startIndex, length);
        }
    }
}
