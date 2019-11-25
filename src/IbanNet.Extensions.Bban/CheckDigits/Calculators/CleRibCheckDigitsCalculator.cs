using System;
using System.Globalization;
using System.Numerics;
using System.Text;
using IbanNet.Extensions;

namespace IbanNet.CheckDigits.Calculators
{
    /// <summary>
    /// Computes the expected national check digits for French bank account numbers, aka. clé RIB (Relevé d'identité bancaire).
    /// </summary>
    /// <remarks>
    /// https://fr.wikipedia.org/wiki/Cl%C3%A9_RIB
    /// </remarks>
    internal class CleRibCheckDigitsCalculator : ICheckDigitsCalculator
    {
        public int Compute(char[] value)
        {
            if (value.Length < 21)
            {
                throw new ArgumentException($"The input '{new string(value)}' can not be validated using clé RIB.", nameof(value));
            }

            var sb = new StringBuilder();
            foreach (char ch in value)
            {
                if (!ch.IsWhitespace())
                {
                    sb.Append(
                        char.IsNumber(ch)
                            ? ch - '0'
                            : MapLetters(ch)
                    );
                }
            }

            string digits = sb.ToString();

            int b = int.Parse(digits.Substring(0, 5));
            int g = int.Parse(digits.Substring(5, 5));
            BigInteger c = BigInteger.Parse(digits.Substring(10), CultureInfo.InvariantCulture);

            BigInteger checkDigits = 97 - (89 * b + 15 * g + 3 * c) % 97;
            return (int)checkDigits;
        }

        private static int MapLetters(char c)
        {
            int v = char.ToUpperInvariant(c) - 'A';
            int digit = v % 9 + 1;
            return c >= 'S' ? ++digit : digit;
        }
    }
}
