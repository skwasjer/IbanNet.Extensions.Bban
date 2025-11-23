using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;
using Buffer = IbanNet.Extensions.Bban.CheckDigits.Buffer;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

/// <summary>
/// National check digits validator for Czech Republic (CZ).
/// </summary>
/// <remarks>
/// The Czech BBAN structure is: bbbb pppppp cccccccccc (20 digits)
/// - Bank code: 4 digits (positions 0-3)
/// - Account prefix: 6 digits (positions 4-9, last digit is check digit)
/// - Account number: 10 digits (positions 10-19, last digit is check digit)
/// This validator checks both the prefix check digit and the account check digit.
/// </remarks>
internal static class CzechRepublic
{
    public sealed class Prefix()
        : NationalCheckDigitsValidator(
            new WeightedMod11Algorithm(Weights),
            CheckString.At(CheckStringPosition, CheckStringLength),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "CZ"
        )
    {
        private const int CheckStringPosition = 4;
        private const int CheckStringLength = 5;
        private const int CheckDigitPosition = CheckStringPosition + CheckStringLength;
        private const int CheckDigitLength = 1;

        // We don't care about the last weight (which = 1), since the input would be padded with a '0' to compute the expected check digit.
        // This would mean that we would add 0x1 = 0 to the total sum, which is redundant.
        private static readonly int[] Weights = [10, 5, 8, 4, 2];
    }

    public sealed class Account()
        : NationalCheckDigitsValidator(
            new WeightedMod11Algorithm(Weights),
            CheckString.At(CheckStringPosition, CheckStringLength),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "CZ"
        )
    {
        private const int CheckStringPosition = 10;
        private const int CheckStringLength = 9;
        private const int CheckDigitPosition = CheckStringPosition + CheckStringLength;
        private const int CheckDigitLength = 1;

        // We don't care about the last weight (which = 1), since the input would be padded with a '0' to compute the expected check digit.
        // This would mean that we would add 0x1 = 0 to the total sum, which is redundant.
        private static readonly int[] Weights = [6, 3, 7, 9, 10, 5, 8, 4, 2];
    }

    internal sealed class WeightedMod11Algorithm(int[] weights) : CheckDigitsAlgorithm
    {
        protected override int Compute(Buffer buffer)
        {
            if (buffer.Length != weights.Length)
            {
                throw new ArgumentException($"The input must be exactly {weights.Length} digits for Czech validation.", nameof(buffer));
            }

            int sum = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                int value = buffer.GetDigitValue(i);
                sum += value * weights[i];
            }

            int remainder = sum % 11;
            return remainder == 0 ? 0 : 11 - remainder;
        }
    }
}
