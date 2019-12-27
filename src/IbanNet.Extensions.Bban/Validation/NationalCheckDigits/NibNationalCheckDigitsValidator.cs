using IbanNet.CheckDigits.Calculators;

namespace IbanNet.Validation.NationalCheckDigits
{
    internal class NibNationalCheckDigitsValidator : NationalCheckDigitsValidator
    {
        private const int CheckDigitCount = 2;

        public NibNationalCheckDigitsValidator() : base(new NibCheckDigitsCalculator(), "PT")
        {
        }

        protected override string GetCheckString(string bban)
        {
            return bban.Substring(0, bban.Length - CheckDigitCount);
        }

        protected override int GetExpectedCheckDigits(string bban)
        {
            return int.Parse(bban.Substring(bban.Length - CheckDigitCount));
        }
    }
}
