using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal sealed class FranceMonacoAndMauritania : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 21;
    private const int CheckDigitLength = 2;

    public FranceMonacoAndMauritania()
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
