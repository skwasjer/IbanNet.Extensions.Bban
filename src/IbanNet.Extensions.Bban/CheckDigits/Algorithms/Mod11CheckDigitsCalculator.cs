using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// Computes the expected national check digits using MOD-11.
/// </summary>
/// <remarks>
/// https://no.wikipedia.org/wiki/MOD11
/// </remarks>
internal class Mod11CheckDigitsCalculator : ICheckDigitsAlgorithm
{
    public int Compute(char[] value)
    {
        int sum = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];
            if (!c.IsAsciiDigit())
            {
                throw new InvalidTokenException("Expected numeric characters.");
            }

            int weight = 7 - (i + 2) % 6;
            sum += (c - '0') * weight;
        }

        int remainder = sum % 11;
        return remainder == 0 ? 0 : 11 - remainder;
    }
}
