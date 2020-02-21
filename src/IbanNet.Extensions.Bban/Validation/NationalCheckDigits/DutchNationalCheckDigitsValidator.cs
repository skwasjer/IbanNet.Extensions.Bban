using System;
using IbanNet.Extensions.Bban.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits
{
    internal class DutchNationalCheckDigitsValidator : NationalCheckDigitsValidator
    {
        public DutchNationalCheckDigitsValidator() : base(new InverseWeightedMod11CheckDigitsCalculator(), "NL")
        {
        }

        public override bool Validate(string bban)
        {
            // Exception for INGB (former) postbank account numbers. If more than 1 leading zero, skip check digit validation.
            return bban.StartsWith("INGB00") || base.Validate(bban);
        }

        protected override string GetCheckString(string bban)
        {
            return bban.Substring(4);
        }

        protected override int GetExpectedCheckDigits(string bban)
        {
            return 0;
        }
    }
}
