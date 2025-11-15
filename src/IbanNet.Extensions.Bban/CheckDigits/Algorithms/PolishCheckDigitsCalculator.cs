using System;
using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// Computes the expected national check digits for Polish bank account numbers.
/// </summary>
/// <remarks>
/// The Polish BBAN uses a weighted MOD-10 algorithm for the bank code check digit.
/// The bank code consists of 7 digits followed by 1 check digit (8th position).
/// Weights: [3, 9, 7, 1, 3, 9, 7] applied to first 7 digits.
/// https://en.wikipedia.org/wiki/International_Bank_Account_Number#National_check_digits
/// https://pl.wikipedia.org/wiki/Numer_rachunku_bankowego
/// </remarks>
internal class PolishCheckDigitsCalculator : ICheckDigitsCalculator
{
    private static readonly int[] Weights = [3, 9, 7, 1, 3, 9, 7];

    public int Compute(char[] value)
    {
        if (value.Length != 7)
        {
            throw new ArgumentException($"The input '{new string(value)}' must be exactly 7 digits for Polish bank code validation.", nameof(value));
        }

        int sum = 0;

        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];
            if (!c.IsAsciiDigit())
            {
                throw new InvalidTokenException("Expected numeric characters.");
            }

            sum += (c - '0') * Weights[i];
        }

        int remainder = sum % 10;
        return remainder == 0 ? 0 : 10 - remainder;
    }
}
