using IbanNet.Extensions.Bban.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal class BosniaAndHerzegovinaMod97NationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 14;
    private const int CheckDigitLength = 2;

    public BosniaAndHerzegovinaMod97NationalCheckDigitsValidator()
        : base(
            new Mod97From98CheckDigitsCalculator(),
            // Check string must be padded with 2 zeros.
            bban => CheckString.At(0, CheckDigitPosition)(bban) + "00",
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "BA")
    {
    }
}
