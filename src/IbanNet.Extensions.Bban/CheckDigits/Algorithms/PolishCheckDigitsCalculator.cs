using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// Computes the expected national check digits for Polish bank account numbers.
/// </summary>
/// <remarks>
/// The Polish BBAN uses a weighted MOD-10 algorithm for the bank code check digit.
/// The bank code consists of 7 digits followed by 1 check digit (8th position).
/// Weights: [3, 9, 7, 1, 3, 9, 7] applied to first 7 digits.
/// https://en.wikipedia.org/wiki/International_Bank_Account_Number#National_check_digits
/// https://pl.wikipedia.org/wiki/Numer_rachunku_bankowego
/// </remarks>
internal class PolishCheckDigitsCalculator : CheckDigitsAlgorithm
{
    private static readonly int[] Weights = [3, 9, 7, 1, 3, 9, 7];

    protected override int Compute(Buffer buffer)
    {
        if (buffer.Length != 7)
        {
            throw new ArgumentException($"The input '{buffer.ToString()}' must be exactly 7 digits for Polish bank code validation.", nameof(buffer));
        }

        int sum = 0;

        for (int i = 0; i < buffer.Length; i++)
        {
            char c = buffer[i];
            if (!c.IsAsciiDigit())
            {
                throw new InvalidTokenException("numeric", i, c);
            }

            sum += (c - '0') * Weights[i];
        }

        int remainder = sum % 10;
        return remainder == 0 ? 0 : 10 - remainder;
    }
}
