using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal class CleRibNationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 21;
    private const int CheckDigitLength = 2;

    public CleRibNationalCheckDigitsValidator()
        : base(
            new CleRibAlgorithm(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "FR",
            "MR",
            "MC")
    {
    }
}
