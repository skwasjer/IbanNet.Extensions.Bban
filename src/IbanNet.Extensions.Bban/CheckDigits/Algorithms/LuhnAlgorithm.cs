using System.Runtime.CompilerServices;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// Luhn check digit algorithm.
/// </summary>
/// <remarks>
/// The Luhn algorithm is a MOD-10 algorithm with alternating doubling.
/// Weights: [2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, etc.]
/// When weight × digit ≥ 10, the individual digits of the product are summed.
/// For example: 2 × 6 = 12 → 1 + 2 = 3
/// https://en.wikipedia.org/wiki/International_Bank_Account_Number#National_check_digits
/// https://fi.wikipedia.org/wiki/Tilinumero
/// </remarks>
internal sealed class LuhnAlgorithm : CheckDigitsAlgorithm
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override int Compute(Buffer buffer)
    {
        int sum = 0;

        // Start from last char working our way back to the beginning.
        int i = buffer.Length - 1;
        for (int j = 0; j < buffer.Length; j++)
        {
            int value = ConvertChar(buffer, i);

            // Double every 2nd.
            int weightedValue = (j & 1) == 0
                ? value << 1
                : value;

            // Sum digits if > 9.
            sum += weightedValue > 9
                ? weightedValue - 9
                : weightedValue;
            i--;
        }

        int remainder = sum % 10;
        return remainder == 0
            ? 0
            : 10 - remainder;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ConvertChar(Buffer buffer, int index)
    {
        char ch = buffer[index];
        if (ch.IsAsciiDigit())
        {
            return ch - '0';
        }

        throw new InvalidTokenException("numeric", index, ch);
    }
}
