using IbanNet.Extensions.Bban.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal class BelgiumMod97NationalCheckDigitsValidator : NationalCheckDigitsValidator
{
    public BelgiumMod97NationalCheckDigitsValidator() : base(new Mod97NoZeroCheckDigitsCalculator(), "BE")
    {
    }

    protected override string GetCheckString(string bban)
    {
        return bban.Substring(0, bban.Length - 2);
    }

    protected override int GetExpectedCheckDigits(string bban)
    {
        return int.Parse(bban.Substring(bban.Length - 2));
    }
}
