using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// Computes the expected national check digits for Czech bank account numbers.
/// </summary>
/// <remarks>
/// The Czech BBAN uses a dual MOD-11 algorithm with two separate check digits:
/// 1. Account prefix check digit (6 digits) - Weights: [10, 5, 8, 4, 2, 1]
/// 2. Account number check digit (10 digits) - Weights: [6, 3, 7, 9, 10, 5, 8, 4, 2, 1]
/// 
/// The BBAN structure is: bbbb pppppp cccccccccc
///   - Bank code: 4 digits
///   - Account prefix: 6 digits (last digit is check digit)
///   - Account number: 10 digits (last digit is check digit)
/// 
/// https://en.wikipedia.org/wiki/International_Bank_Account_Number#National_check_digits
/// </remarks>
internal static class CzechCheckDigitsCalculator
{
    private static readonly int[] PrefixWeights = [10, 5, 8, 4, 2, 1];
    private static readonly int[] AccountWeights = [6, 3, 7, 9, 10, 5, 8, 4, 2, 1];

    /// <summary>
    /// Computes the check digit for the 6-digit account prefix.
    /// </summary>
    public static int ComputePrefixCheckDigit(char[] value)
    {
        if (value.Length != 6)
        {
            throw new InvalidTokenException($"The input '{new string(value)}' must be exactly 6 digits for Czech prefix validation.");
        }

        return ComputeCheckDigit(value, PrefixWeights);
    }

    /// <summary>
    /// Computes the check digit for the 10-digit account number.
    /// </summary>
    public static int ComputeAccountCheckDigit(char[] value)
    {
        if (value.Length != 10)
        {
            throw new InvalidTokenException($"The input '{new string(value)}' must be exactly 10 digits for Czech account number validation.");
        }

        return ComputeCheckDigit(value, AccountWeights);
    }

    private static int ComputeCheckDigit(char[] value, int[] weights)
    {
        int sum = 0;

        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];
            if (!c.IsAsciiDigit())
            {
                throw new InvalidTokenException("Expected numeric characters.");
            }

            sum += (c - '0') * weights[i];
        }

        int remainder = sum % 11;
        return remainder == 0 ? 0 : 11 - remainder;
    }
}
