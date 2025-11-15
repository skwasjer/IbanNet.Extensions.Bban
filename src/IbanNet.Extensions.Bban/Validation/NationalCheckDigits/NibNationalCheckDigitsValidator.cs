using IbanNet.Extensions.Bban.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal class NibNationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 19;
    private const int CheckDigitLength = 2;

    public NibNationalCheckDigitsValidator()
        : base(
            new NibCheckDigitsCalculator(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "PT")
    {
    }
}
