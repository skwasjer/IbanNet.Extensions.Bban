using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal class BelgiumMod97NationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 10;
    private const int CheckDigitLength = 2;

    /// <summary>
    /// The complement is a variation specific to Belgium.
    /// </summary>
    private static readonly Complement Complement = (modulo, remainder)
        => remainder == 0
            ? modulo
            : remainder;

    public BelgiumMod97NationalCheckDigitsValidator()
        : base(
            new Mod9710Algorithm(Complement),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "BE")
    {
    }
}
