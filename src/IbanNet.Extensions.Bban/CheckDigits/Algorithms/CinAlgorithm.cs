using System.Runtime.CompilerServices;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// CIN check digit algorithm, used in Italy.
/// </summary>
/// <remarks>
/// http://www.artico.name/soft/iban/wiban.htm#cin
/// </remarks>
internal sealed class CinAlgorithm : CheckDigitsAlgorithm
{
    private static readonly int[] OddWeights = [1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override int Compute(Buffer buffer)
    {
        int sum = 0;

        // Avoid branching in the loop by just looping for odd/even individually.

        // Odd weights (1-based index).
        for (int i = 0; i < buffer.Length; i += 2)
        {
            int value = ConvertChar(buffer, i);
            sum += OddWeights[value];
        }

        // Even weights (1-based index).
        for (int i = 1; i < buffer.Length; i += 2)
        {
            int value = ConvertChar(buffer, i);
            // The even weights are exactly the converted value.
            sum += value;
        }

        return sum % 26;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ConvertChar(Buffer buffer, int index)
    {
        char ch = buffer[index];
        if (ch.IsAsciiDigit())
        {
            return ch - '0';
        }

        if (ch.IsAsciiLetter())
        {
            return (ch | ' ') - 'a';
        }

        throw new InvalidTokenException("alphanumeric", index, ch);
    }
}
