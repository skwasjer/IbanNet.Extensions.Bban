using System;
using System.Numerics;
using IbanNet.Extensions;

namespace IbanNet.CheckDigits.Calculators
{
    /// <summary>
    /// Computes the expected national check digits for Portugal bank account numbers, aka. NIB (Número de Identificação Bancária).
    /// </summary>
    /// <remarks>
    /// https://pt.wikipedia.org/wiki/N%C3%BAmero_de_Identifica%C3%A7%C3%A3o_Banc%C3%A1ria
    /// </remarks>
    internal class NibCheckDigitsCalculator : ICheckDigitsCalculator
    {
        private static readonly int[] Weights = { 73, 17, 89, 38, 62, 45, 53, 15, 50, 5, 49, 34, 81, 76, 27, 90, 9, 30, 3 };

        public int Compute(char[] value)
        {
            if (value.Length < 19)
            {
                throw new ArgumentException($"The input '{new string(value)}' can not be validated using NIB.", nameof(value));
            }

            long sum = 0;

            for (int i = 0; i < value.Length; i++)
            {
                char ch = value[i];
                int add = ch.IsAsciiDigit()
                    ? ch - '0'
                    : ch.IsAsciiLetter()
                        ? MapLetters(ch)
                        : throw new InvalidOperationException("Expected alphanumeric characters.");
                sum += (add * Weights[i]);
            }

            return 98 - ((int) sum % 97);
        }

        private static int MapLetters(char c)
        {
            int v = (c | ' ') - 'a';
            int digit = v % 9 + 1;
            return c >= 'S' ? ++digit : digit;
        }
    }
}
