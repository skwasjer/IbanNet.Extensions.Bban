using System.Runtime.CompilerServices;

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
            int value = buffer.GetOrdinalValue(i);
            sum += OddWeights[value];
        }

        // Even weights (1-based index).
        for (int i = 1; i < buffer.Length; i += 2)
        {
            int value = buffer.GetOrdinalValue(i);
            // The even weights are exactly the converted value.
            sum += value;
        }

        return sum % 26;
    }
}
