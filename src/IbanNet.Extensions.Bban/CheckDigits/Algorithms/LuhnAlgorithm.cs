using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// Computes the expected national check digits for Finnish bank account numbers using the Luhn algorithm.
/// </summary>
/// <remarks>
/// The Finnish BBAN uses the Luhn algorithm (MOD-10 with alternating doubling).
/// The BBAN consists of 14 digits: bank+branch (6), account (7), and check digit (1).
/// Weights: [2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2] applied to first 13 digits.
/// When weight × digit ≥ 10, the individual digits of the product are summed.
/// For example: 2 × 6 = 12 → 1 + 2 = 3
/// https://en.wikipedia.org/wiki/International_Bank_Account_Number#National_check_digits
/// https://fi.wikipedia.org/wiki/Tilinumero
/// </remarks>
internal class LuhnAlgorithm : ICheckDigitsAlgorithm
{
    private static readonly int[] Weights = [2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2];

    public int Compute(char[] value)
    {
        if (value.Length != 13)
        {
            throw new InvalidTokenException($"The input '{new string(value)}' must be exactly 13 digits for Finnish BBAN validation.");
        }

        int sum = 0;

        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];
            if (!c.IsAsciiDigit())
            {
                throw new InvalidTokenException("Expected numeric characters.");
            }

            int product = (c - '0') * Weights[i];
            
            // Luhn algorithm: sum the digits of products ≥ 10
            if (product >= 10)
            {
                sum += (product / 10) + (product % 10);
            }
            else
            {
                sum += product;
            }
        }

        int remainder = sum % 10;
        return remainder == 0 ? 0 : 10 - remainder;
    }
}
