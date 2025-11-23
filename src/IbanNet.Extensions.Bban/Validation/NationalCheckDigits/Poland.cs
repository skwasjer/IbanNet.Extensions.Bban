using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;
using Buffer = IbanNet.Extensions.Bban.CheckDigits.Buffer;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// National check digits validator for Poland (PL).
/// </summary>
/// <remarks>
/// The Polish BBAN structure is: 8-digit bank code + 16-digit account number.
/// The 8th digit of the bank code is a check digit calculated from the first 7 digits.
/// </remarks>
internal sealed class Poland : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 7; // 0-based index
    private const int CheckDigitLength = 1;

    public Poland()
        : base(
            new WeightedMod10Algorithm(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "PL")
    {
    }

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
    internal sealed class WeightedMod10Algorithm : CheckDigitsAlgorithm
    {
        private static readonly int[] Weights = [3, 9, 7, 1, 3, 9, 7];

        protected override int Compute(Buffer buffer)
        {
            if (buffer.Length != Weights.Length)
            {
                throw new ArgumentException($"The input '{buffer.ToString()}' must be exactly 7 digits for Polish bank code validation.", nameof(buffer));
            }

            int sum = 0;

            for (int i = 0; i < buffer.Length; i++)
            {
                int value = buffer.GetDigitValue(i);
                sum += value * Weights[i];
            }

            int remainder = sum % 10;
            return remainder == 0 ? 0 : 10 - remainder;
        }
    }

}
