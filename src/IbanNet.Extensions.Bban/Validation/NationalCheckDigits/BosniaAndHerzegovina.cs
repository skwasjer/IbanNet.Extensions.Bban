using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal sealed class BosniaAndHerzegovina : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 14;
    private const int CheckDigitLength = 2;

    public BosniaAndHerzegovina()
        : base(
            // Check string must be padded with 2 zeroes.
            new Mod9710Algorithm(Complement.DivisorPlusOneMinusRemainder.PadRight(2)),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "BA")
    {
    }
}
