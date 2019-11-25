namespace IbanNet.CheckDigits.Calculators
{
    /// <summary>
    /// Computes the expected national check digits using MOD-11.
    /// </summary>
    /// <remarks>
    /// https://no.wikipedia.org/wiki/MOD11
    /// </remarks>
    internal class Mod11CheckDigitsCalculator : ICheckDigitsCalculator
    {
        public int Compute(char[] value)
        {
            int sum = 0;
            int pos = 0;
            for (int i = value.Length - 1; i >= 0; i--)
            {
                char c = value[i];
                int weight = pos++ % 6 + 2;
                sum += (char.ToUpperInvariant(c) - '0') * weight;
            }

            return 11 - sum % 11;
        }
    }
}
