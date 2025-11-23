using System.Runtime.CompilerServices;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// NIB (Número de Identificação Bancária) check digit algorithm.
/// </summary>
/// <remarks>
/// https://pt.wikipedia.org/wiki/N%C3%BAmero_de_Identifica%C3%A7%C3%A3o_Banc%C3%A1ria
/// </remarks>
internal sealed class NibAlgorithm : CheckDigitsAlgorithm
{
    private const int Modulo = 97;
    private static readonly int[] Weights = [73, 17, 89, 38, 62, 45, 53, 15, 50, 5, 49, 34, 81, 76, 27, 90, 9, 30, 3];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override int Compute(Buffer buffer)
    {
        if (buffer.Length != Weights.Length)
        {
            throw new ArgumentException($"The input '{buffer.ToString()}' can not be validated using NIB.", nameof(buffer));
        }

        int sum = 0;

        for (int i = 0; i < buffer.Length; i++)
        {
            int value = buffer.GetAlphaNumericBase10Value(i);
            sum += value * Weights[i];
        }

        return Modulo - (sum % Modulo) + 1;
    }
}
