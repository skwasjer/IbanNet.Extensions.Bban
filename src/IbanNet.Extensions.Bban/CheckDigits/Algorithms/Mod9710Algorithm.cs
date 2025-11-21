using System.Diagnostics;
using IbanNet.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// ISO 7064 Mod 97,10 check digit algorithm.
/// </summary>
/// <param name="complement">The complement to return.</param>
internal sealed class Mod9710Algorithm(Complement complement) : ICheckDigitsAlgorithm
{
    /// <summary>
    /// 8 because with 2 more digits added, we are risking integer overflow.
    /// </summary>
    private const int MaxDigitsBeforeIntegerOverflow = 8;
    private const int Modulo = 97;
    private readonly Complement _complement = complement ?? throw new ArgumentNullException(nameof(complement));

    /// <summary>
    /// Gets the delegate used to translate an ASCII character to an integer value.
    /// </summary>
    public AsciiConverter AsciiConverter { get; init; } = AsciiConverter.Base36;

    public int Compute(char[] value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        int digits = 0;
        int remainder = 0;
        // ReSharper disable once ForCanBeConvertedToForeach - justification : performance
        for (int i = 0; i < value.Length; i++)
        {
            char ch = value[i];
            int number = AsciiConverter(ch);
            Debug.Assert(
                number is >= 0 and < Modulo,
                $"Value {number} for character '{ch}' is not valid in Mod 97,10 calculation."
            );

            // If the number we got is a two-digit number (i.e. >= 10) we need to shift left by 100, else by 10.
            int numberDigits = 2;
            int base10Shift = 100;
            if (number < 10)
            {
                numberDigits = 1;
                base10Shift = 10;
            }

            remainder = remainder * base10Shift + number;
            if (digits + numberDigits >= MaxDigitsBeforeIntegerOverflow)
            {
                // Compute the new remainder to avoid integer overflow and reset the number of digits.
                remainder %= Modulo;
                digits = remainder < 10 ? 1 : 2;
            }
            else
            {
                digits += numberDigits;
            }
        }

        if (remainder >= Modulo)
        {
            remainder %= Modulo;
        }

        return _complement(Modulo, remainder);
    }
}
