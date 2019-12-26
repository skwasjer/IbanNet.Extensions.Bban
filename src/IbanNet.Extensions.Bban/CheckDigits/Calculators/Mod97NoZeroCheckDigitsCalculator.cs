namespace IbanNet.CheckDigits.Calculators
{
    internal class Mod97NoZeroCheckDigitsCalculator : Mod97CheckDigitsCalculator, ICheckDigitsCalculator
    {
        public new int Compute(char[] value)
        {
            var mod97 = base.Compute(value);
            return mod97 == 0
                ? 97
                : mod97;
        }
    }
}
