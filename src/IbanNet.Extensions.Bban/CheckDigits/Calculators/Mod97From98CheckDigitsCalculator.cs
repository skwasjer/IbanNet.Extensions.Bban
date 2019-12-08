namespace IbanNet.CheckDigits.Calculators
{
    internal class Mod97From98CheckDigitsCalculator : ICheckDigitsCalculator
    {
        private readonly Mod97CheckDigitsCalculator _innerCalculator;

        public Mod97From98CheckDigitsCalculator()
        {
            _innerCalculator = new Mod97CheckDigitsCalculator();
        }

        /// <inheritdoc />
        public int Compute(char[] value)
        {
            return 98 - _innerCalculator.Compute(value);
        }
    }
}
