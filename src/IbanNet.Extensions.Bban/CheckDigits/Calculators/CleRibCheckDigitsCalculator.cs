using System;
using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Calculators;

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

        long b = 0, g = 0, c = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char ch = value[i];
            int add = ch.IsAsciiDigit()
                ? ch - '0'
                : ch.IsAsciiLetter()
                    ? MapLetters(ch)
                    : throw new InvalidTokenException("Expected alphanumeric characters.");
            if (i < 5)
            {
                b = b * 10 + add;
            }
            else if (i < 10)
            {
                g = g * 10 + add;
            }
            else
            {
                c = c * 10 + add;
            }
        }

        return (int)(97 - (89 * b + 15 * g + 3 * c) % 97);
    }

    private static int MapLetters(char c)
    {
        int v = (c | ' ') - 'a';
        int digit = v % 9 + 1;
        return c >= 'S' ? ++digit : digit;
    }
}
