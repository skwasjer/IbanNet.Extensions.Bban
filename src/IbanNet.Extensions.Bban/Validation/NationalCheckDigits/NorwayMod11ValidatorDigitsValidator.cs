using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal class NorwayMod11ValidatorDigitsValidator : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 10;
    private const int CheckDigitLength = 1;

    public NorwayMod11ValidatorDigitsValidator()
        : base(
            new Mod11CheckDigitsCalculator(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "NO")
    {
    }

    public override bool Validate(string bban)
    {
        if (bban.Substring(4, 2) == "00")
        {
            return true;
        }

        return base.Validate(bban);
    }
}
