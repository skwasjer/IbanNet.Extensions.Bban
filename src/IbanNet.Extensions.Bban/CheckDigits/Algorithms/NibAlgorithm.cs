using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// Computes the expected national check digits for Portugal bank account numbers, aka. NIB (Número de Identificação Bancária).
/// </summary>
/// <remarks>
/// https://pt.wikipedia.org/wiki/N%C3%BAmero_de_Identifica%C3%A7%C3%A3o_Banc%C3%A1ria
/// </remarks>
internal class NibAlgorithm : CheckDigitsAlgorithm
{
    private static readonly int[] Weights = [73, 17, 89, 38, 62, 45, 53, 15, 50, 5, 49, 34, 81, 76, 27, 90, 9, 30, 3];

    protected override int Compute(Buffer buffer)
    {
        if (buffer.Length < 19)
        {
            throw new ArgumentException($"The input '{buffer.ToString()}' can not be validated using NIB.", nameof(buffer));
        }

        long sum = 0;

        for (int i = 0; i < buffer.Length; i++)
        {
            char ch = buffer[i];
            int add = ch.IsAsciiDigit()
                ? ch - '0'
                : ch.IsAsciiLetter()
                    ? MapLetters(ch)
                    : throw new InvalidTokenException("alphanumeric", i, ch);
            sum += (add * Weights[i]);
        }

        return 98 - ((int)sum % 97);
    }

    private static int MapLetters(char c)
    {
        int v = (c | ' ') - 'a';
        int digit = v % 9 + 1;
        return c >= 'S' ? ++digit : digit;
    }
}
