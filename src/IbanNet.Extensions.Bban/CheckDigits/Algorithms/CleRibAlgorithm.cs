using System.Runtime.CompilerServices;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// Clé RIB (Relevé d'identité bancaire) check digit algorithm, used in France.
/// </summary>
/// <remarks>
/// https://fr.wikipedia.org/wiki/Cl%C3%A9_RIB
/// </remarks>
internal sealed class CleRibAlgorithm : CheckDigitsAlgorithm
{
    private const int Modulo = 97;
    private const int RequiredLength = 21;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override int Compute(Buffer buffer)
    {
        if (buffer.Length != RequiredLength)
        {
            throw new ArgumentException($"The input '{buffer.ToString()}' can not be validated using clé RIB.", nameof(buffer));
        }

        long b = 0, g = 0, c = 0;
        for (int i = 0; i < buffer.Length; i++)
        {
            int value = ConvertChar(buffer, i);

            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (i < 5)
            {
                b = b * 10 + value;
            }
            else if (i < 10)
            {
                g = g * 10 + value;
            }
            else
            {
                c = c * 10 + value;
            }
        }

        return (int)(Modulo - (89 * b + 15 * g + 3 * c) % Modulo);
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
