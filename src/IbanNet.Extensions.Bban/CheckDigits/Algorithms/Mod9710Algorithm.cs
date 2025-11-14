using IbanNet.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

/// <summary>
/// ISO 7064 Mod 97,10 check digit algorithm.
/// </summary>
/// <param name="complement">The complement to return.</param>
internal sealed class Mod9710Algorithm(Complement complement) : ICheckDigitsCalculator
{
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

        int remainder = 0;
        // ReSharper disable once ForCanBeConvertedToForeach - justification : performance
        for (int i = 0; i < value.Length; i++)
        {
            char ch = value[i];
            int number = AsciiConverter(ch);
            if (number is < 0 or >= Modulo)
            {
                throw new InvalidTokenException($"Character '{ch}' is not valid in Mod 97,10 calculation.");
            }

            // If the number we got is a two-digit number (i.e. >= 10) we need to shift left by 100, else by 10.
            int base10Shift = number < 10 ? 10 : 100;
            remainder = (remainder * base10Shift + number) % Modulo;
        }

        return _complement(Modulo, remainder);
    }
}
