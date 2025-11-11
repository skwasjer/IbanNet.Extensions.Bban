using System.Globalization;
using IbanNet.Extensions.Bban.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// National check digits validator for Finland (FI).
/// </summary>
/// <remarks>
/// The Finnish BBAN structure is: 6-digit bank+branch code + 7-digit account number + 1-digit check digit.
/// The check digit (14th position) is calculated using the Luhn algorithm on the first 13 digits.
/// </remarks>
internal class FinnishNationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 13;  // 0-based index

    public FinnishNationalCheckDigitsValidator()
        : base(new FinnishCheckDigitsCalculator(), "FI")
    {
    }

    protected override string GetCheckString(string bban)
    {
        // First 13 digits of the BBAN
        return bban.Substring(0, CheckDigitPosition);
    }

    protected override int GetExpectedCheckDigits(string bban)
    {
        // The 14th digit is the check digit
        return int.Parse(bban.Substring(CheckDigitPosition, 1), CultureInfo.InvariantCulture);
    }
}
