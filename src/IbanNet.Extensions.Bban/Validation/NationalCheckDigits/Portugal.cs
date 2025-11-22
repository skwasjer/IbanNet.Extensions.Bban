using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal sealed class Portugal : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 19;
    private const int CheckDigitLength = 2;

    public Portugal()
        : base(
            new NibAlgorithm(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "PT")
    {
    }
}
