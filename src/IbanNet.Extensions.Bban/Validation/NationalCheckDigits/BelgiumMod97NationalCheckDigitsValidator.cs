using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal class BelgiumMod97NationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 10;
    private const int CheckDigitLength = 2;

    public BelgiumMod97NationalCheckDigitsValidator()
        : base(
            new Mod97NoZeroCheckDigitsCalculator(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "BE")
    {
    }
}
