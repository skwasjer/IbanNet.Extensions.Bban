using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal sealed class ItalyAndSanMarino : NationalCheckDigitsValidator
{
    private const int CharCodeA = 'A';
    private const int CheckDigitLength = 1;

    public ItalyAndSanMarino()
        : base(
            new CinAlgorithm(),
            CheckString.At(CheckDigitLength),
            bban => bban[0] - CharCodeA,
            "IT",
            "SM")
    {
    }
}
