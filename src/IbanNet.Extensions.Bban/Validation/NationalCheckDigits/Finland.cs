using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// National check digits validator for Finland (FI).
/// </summary>
/// <remarks>
/// The Finnish BBAN structure is: 6-digit bank+branch code + 7-digit account number + 1-digit check digit.
/// The check digit (14th position) is calculated using the Luhn algorithm on the first 13 digits.
/// </remarks>
internal sealed class Finland : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 13; // 0-based index
    private const int CheckDigitLength = 1;

    public Finland()
        : base(
            new LuhnAlgorithm(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "FI")
    {
    }
}
