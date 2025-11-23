using System.Runtime.CompilerServices;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// ISO 7064 Mod 97,10 check digit algorithm.
/// </summary>
/// <param name="complement">The complement to return.</param>
internal sealed class Mod9710Algorithm(Complement complement) : CheckDigitsAlgorithm
{
    /// <summary>
    /// 8 because with 2 more digits added, we are risking integer overflow.
    /// </summary>
    private const int MaxDigitsBeforeIntegerOverflow = 8;
    private const int Modulo = 97;
    private readonly Complement _complement = complement ?? throw new ArgumentNullException(nameof(complement));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override int Compute(Buffer buffer)
    {
        int digits = 0;
        int remainder = 0;
        // ReSharper disable once ForCanBeConvertedToForeach - justification : performance
        for (int i = 0; i < buffer.Length; i++)
        {
            int value = buffer.GetBase36Value(i);

            // If the number we got is a two-digit number (i.e. >= 10) we need to shift left by 100, else by 10.
            int valueDigits = 2;
            int base10Shift = 100;
            if (value < 10)
            {
                valueDigits = 1;
                base10Shift = 10;
            }

            remainder = remainder * base10Shift + value;
            if (digits + valueDigits >= MaxDigitsBeforeIntegerOverflow)
            {
                // Compute the new remainder to avoid integer overflow and reset the number of digits.
                remainder %= Modulo;
                digits = remainder < 10 ? 1 : 2;
            }
            else
            {
                digits += valueDigits;
            }
        }

        if (remainder >= Modulo)
        {
            remainder %= Modulo;
        }

        return _complement(Modulo, remainder);
    }
}
