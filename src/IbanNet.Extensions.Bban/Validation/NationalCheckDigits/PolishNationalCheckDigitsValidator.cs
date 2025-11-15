using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

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
    private const int CheckDigitPosition = 7; // 0-based index
    private const int CheckDigitLength = 1;

    public PolishNationalCheckDigitsValidator()
        : base(
            new PolishCheckDigitsCalculator(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "PL")
    {
    }
}
