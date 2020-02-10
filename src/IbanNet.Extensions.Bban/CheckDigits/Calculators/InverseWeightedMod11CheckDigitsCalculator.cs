using System;
using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Calculators
{
    /// <summary>
    /// Computes the expected national check digits by using the inverse of the digit position as a weight, summing and returning the result of MOD-11.
    /// </summary>
    internal class InverseWeightedMod11CheckDigitsCalculator : ICheckDigitsCalculator
    {
        private static readonly int[] _weights = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        public int Compute(char[] value)
        {
            if (value.Length > _weights.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The input value must be less than or equal to 10 characters.");
            }

            int sum = 0;
            int offset = _weights.Length - value.Length;
            for (int i = 0; i < value.Length; i++)
            {
                char ch = value[i];
                if (!ch.IsAsciiDigit())
                {
                    throw new InvalidTokenException($"Expected digit at position {i}, but found '{ch}'.");
                }

                sum += _weights[i + offset] * (ch - '0');
            }

            return sum % 11;
        }
    }
}
