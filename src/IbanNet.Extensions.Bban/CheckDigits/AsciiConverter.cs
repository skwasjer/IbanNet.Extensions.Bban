using System.Runtime.CompilerServices;
using IbanNet.Extensions.Bban.Extensions;

namespace IbanNet.Extensions.Bban.CheckDigits;

/// <summary>
/// A delegate that converts an ASCII character to its corresponding integer value. Note that this does not
/// have to be its underlying ASCII binary value, but rather the value it represents in the context of the check
/// digit algorithm (e.g., '0' to 0, 'A' to 10, etc.).
/// </summary>
/// <param name="ch">The character.</param>
/// <returns>The integer value the character represents.</returns>
internal delegate int AsciiConverter(char ch);

internal static class AsciiConverterExtensions
{
    extension(AsciiConverter)
    {
        /// <summary>
        /// Converts digits '0' to '9' to their corresponding integer values 0 to 9.
        /// </summary>
        public static AsciiConverter Digits
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ch =>
                {
                    if (ch.IsAsciiDigit())
                    {
                        return ch - '0';
                    }

                    throw new InvalidTokenException($"Character '{ch}' is not a valid digit character.");
                };
            }
        }

        /// <summary>
        /// Converts alphanumeric characters '0'-'9' and 'A'-'Z' to their corresponding base-36 integer values where '0' = 0, 'A' = 10, etc. Lower case letters are also supported and considered as upper case.
        /// </summary>
        public static AsciiConverter Base36
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ch =>
                {
                    if (ch.IsAsciiDigit())
                    {
                        return ch - '0';
                    }

                    if (ch.IsAsciiLetter())
                    {
                        return (ch | ' ') - 'a' + 10;
                    }

                    throw new InvalidTokenException($"Character '{ch}' is not a valid alphanumeric character.");
                };
            }
        }
    }
}
