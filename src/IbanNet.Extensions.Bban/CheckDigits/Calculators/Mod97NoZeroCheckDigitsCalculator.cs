using IbanNet.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.CheckDigits.Calculators
{
    internal class Mod97NoZeroCheckDigitsCalculator : ICheckDigitsCalculator
    {
        private readonly Mod97CheckDigitsCalculator _innerCalculator;

        public Mod97NoZeroCheckDigitsCalculator()
        {
            _innerCalculator = new Mod97CheckDigitsCalculator();
        }

        /// <inheritdoc />
        public int Compute(char[] value)
        {
            var mod97 = _innerCalculator.Compute(value);
            return mod97 == 0
                ? 97
                : mod97;
        }
    }
}
