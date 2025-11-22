using System.Runtime.CompilerServices;
using IbanNet.Extensions.Bban.Extensions;

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
            int value = ConvertChar(buffer, i);
            sum += value * Weights[i];
        }

        return Modulo - (sum % Modulo) + 1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ConvertChar(Buffer buffer, int index)
    {
        char ch = buffer[index];
        if (ch.IsAsciiDigit())
        {
            return ch - '0';
        }

        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (ch.IsAsciiLetter())
        {
            return MapLetters(ch);
        }

        throw new InvalidTokenException("alphanumeric", index, ch);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int MapLetters(char ch)
    {
        int v = (ch | ' ') - 'a' + 1;
        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (v <= 9)
        {
            return v;
        }

        if (v <= 18)
        {
            return v - 9;
        }

        return v - 17;
    }
}
