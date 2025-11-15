using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal class CinNationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    private const int CharCodeA = 'A';
    private const int CheckDigitLength = 1;

    public CinNationalCheckDigitsValidator()
        : base(
            new CinAlgorithm(),
            CheckString.At(CheckDigitLength),
            bban => bban[0] - CharCodeA,
            "IT",
            "SM")
    {
    }
}
