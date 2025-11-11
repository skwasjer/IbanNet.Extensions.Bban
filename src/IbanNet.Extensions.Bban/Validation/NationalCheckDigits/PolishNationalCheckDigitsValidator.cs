using System.Globalization;
using IbanNet.Extensions.Bban.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// National check digits validator for Poland (PL).
/// </summary>
/// <remarks>
/// The Polish BBAN structure is: 8-digit bank code + 16-digit account number.
/// The 8th digit of the bank code is a check digit calculated from the first 7 digits.
/// </remarks>
internal class PolishNationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 7;  // 0-based index

    public PolishNationalCheckDigitsValidator()
        : base(new PolishCheckDigitsCalculator(), "PL")
    {
    }

    protected override string GetCheckString(string bban)
    {
        // First 7 digits of the bank code
        return bban.Substring(0, CheckDigitPosition);
    }

    protected override int GetExpectedCheckDigits(string bban)
    {
        // The 8th digit of the bank code is the check digit
        return int.Parse(bban.Substring(CheckDigitPosition, 1), CultureInfo.InvariantCulture);
    }
}
