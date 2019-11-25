namespace IbanNet.CheckDigits.Calculators
{
    internal class Mod97From98CheckDigitsCalculator : Mod97CheckDigitsCalculator, ICheckDigitsCalculator
    {
        public new int Compute(char[] value)
        {
            return 98 - base.Compute(value);
        }
    }
}
