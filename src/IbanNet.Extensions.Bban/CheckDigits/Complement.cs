namespace IbanNet.Extensions.Bban.CheckDigits;

internal delegate int Complement(int modulo, int remainder);

internal static class ComplementExtensions
{
    /// <summary>
    /// When the check string must be right padded with zeroes, we can also just calculate the new remainder by multiplying
    /// the remainder with <c>10 ^ <paramref name="length" /></c> and applying the modulo again.
    /// </summary>
    /// <param name="complement">The current complement to adjust.</param>
    /// <param name="length">The number of zeroes to pad with.</param>
    /// <returns>A new complement which calculates the remainder after applying padding.</returns>
    public static Complement PadRight(this Complement complement, int length)
    {
        if (complement is null)
        {
            throw new ArgumentNullException(nameof(complement));
        }

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        return (modulo, remainder) => complement(modulo, remainder * (int)Math.Pow(10, length) % modulo);
    }

    extension(Complement)
    {
        /// <summary>
        /// Returns the remainder as is.
        /// </summary>
        public static Complement Remainder
        {
            get => (_, remainder)
                => remainder;
        }

        /// <summary>
        /// Returns <c>modulo - remainder</c>.
        /// </summary>
        public static Complement DivisorMinusRemainder
        {
            get => (modulo, remainder)
                => modulo - remainder;
        }

        /// <summary>
        /// Returns <c>modulo + 1 - remainder</c>.
        /// </summary>
        public static Complement DivisorPlusOneMinusRemainder
        {
            get => (modulo, remainder)
                => 1 + Complement.DivisorMinusRemainder(modulo, remainder);
        }

        /// <summary>
        /// Returns <c>0</c> if remainder is <c>0</c>, otherwise returns <c>modulo - remainder</c>.
        /// </summary>
        public static Complement ZeroRemainderOrDivisorMinusRemainder
        {
            get => (modulo, remainder)
                => remainder == 0 ? 0 : Complement.DivisorMinusRemainder(modulo, remainder);
        }

        /// <summary>
        /// Returns <c>0</c> if remainder is <c>0</c>, <c>1</c> if remainder is <c>1</c>, otherwise returns <c>modulo - remainder</c>.
        /// </summary>
        public static Complement ZeroOrOneRemainderOrDivisorMinusRemainder
        {
            get => (modulo, remainder)
                => remainder == 1 ? 1 : Complement.ZeroRemainderOrDivisorMinusRemainder(modulo, remainder);
        }
    }
}
