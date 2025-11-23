using System.Runtime.CompilerServices;
using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;
using Buffer = IbanNet.Extensions.Bban.CheckDigits.Buffer;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

internal sealed class Norway : NationalCheckDigitsValidator
{
    private const int CheckDigitPosition = 10;
    private const int CheckDigitLength = 1;

    public Norway()
        : base(
            new WeightedMod11Algorithm(),
            CheckString.At(0, CheckDigitPosition),
            CheckDigits.At(CheckDigitPosition, CheckDigitLength),
            "NO")
    {
    }

    public override bool Validate(string bban)
    {
        // If char 4 and 5 are zero, the account number is considered valid without further checks.
#if USE_SPANS
        return bban is [_, _, _, _, '0', '0', ..]
#else
        return (bban.Length >= 6 && bban[4] == '0' && bban[5] == '0')
#endif
         || base.Validate(bban);
    }

    /// <summary>
    /// Weighted MOD-11 check digit algorithm.
    /// Weights: [2,3,4,5,6,7]
    /// Direction: reserved
    /// </summary>
    /// <remarks>
    /// https://no.wikipedia.org/wiki/MOD11
    /// </remarks>
    internal sealed class WeightedMod11Algorithm : CheckDigitsAlgorithm
    {
        private const int Modulo = 11;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected override int Compute(Buffer buffer)
        {
            int sum = 0;

            // Start from last char working our way back to the beginning.
            int weight = 2;
            for (int i = buffer.Length - 1; i >= 0; i--)
            {
                int value = buffer.GetDigitValue(i);
                sum += value * weight;
                if (++weight > 7)
                {
                    weight = 2;
                }
            }

            int remainder = sum % Modulo;
            return remainder == 0
                ? 0
                : Modulo - remainder;
        }
    }
}
