using System.Globalization;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// A delegate to extract the check digit(s) from a BBAN.
/// </summary>
internal delegate int CheckDigits(string bban);

internal static class CheckDigitsExtensions
{
    extension(CheckDigits)
    {
        /// <summary>
        /// Gets the check digit(s) at a fixed known position.
        /// </summary>
        internal static CheckDigits At(int startIndex, int length)
        {
            return bban => int.Parse(bban.Substring(startIndex, length), CultureInfo.InvariantCulture);
        }
    }
}
