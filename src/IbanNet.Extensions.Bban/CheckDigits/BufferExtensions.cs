using System.Runtime.CompilerServices;

namespace IbanNet.Extensions.Bban.CheckDigits;

internal static class BufferExtensions
{
    /// <summary>
    /// Returns the integer value of a digit character at the specified index in the buffer.
    /// </summary>
    /// <param name="buffer">The buffer containing the character to convert. Must contain a numeric character at the specified index.</param>
    /// <param name="index">The zero-based index of the character within the buffer.</param>
    /// <returns>An integer value from 0 to 9 representing the value of the character at the specified index.</returns>
    /// <exception cref="InvalidTokenException">Thrown when the character at the specified index is not a digit.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int GetDigitValue(this Buffer buffer, int index)
    {
        char ch = buffer[index];
        if (ch is >= '0' and <= '9')
        {
            return ch - '0';
        }

        throw new InvalidTokenException("numeric", index, ch);
    }

    /// <summary>
    /// Returns the numeric value of the character at the specified index in the buffer, interpreting it as a base-36
    /// digit.
    /// </summary>
    /// <param name="buffer">The buffer containing the character to convert. Must contain an alphanumeric character at the specified index.</param>
    /// <param name="index">The zero-based index of the character within the buffer.</param>
    /// <returns>An integer value from 0 to 35 representing the base-36 value of the character at the specified index.</returns>
    /// <exception cref="InvalidTokenException">Thrown when the character at the specified index is not an alphanumeric character ('0'–'9', 'a'–'z', or 'A'–'Z').</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int GetBase36Value(this Buffer buffer, int index)
    {
        char ch = buffer[index];
        if (ch is >= '0' and <= '9')
        {
            return ch - '0';
        }

        // Convert to lower case.
        ch |= ' ';

        if (ch is >= 'a' and <= 'z')
        {
            return ch - 'a' + 10;
        }

        throw new InvalidTokenException("alphanumeric", index, ch);
    }

    /// <summary>
    /// Returns the zero-based ordinal value of the alphanumeric character at the specified index in the buffer.
    /// </summary>
    /// <param name="buffer">The buffer containing the character to convert. Must contain an alphanumeric character at the specified index.</param>
    /// <param name="index">The zero-based index of the character within the buffer.</param>
    /// <returns>An integer representing the ordinal value of the character: 0–9 for digits ('0'–'9'), 0–25 for letters (upper and lowercase).</returns>
    /// <exception cref="InvalidTokenException">Thrown when the character at the specified index is not an alphanumeric character ('0'–'9', 'a'–'z', or 'A'–'Z').</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int GetOrdinalValue(this Buffer buffer, int index)
    {
        char ch = buffer[index];
        if (ch is >= '0' and <= '9')
        {
            return ch - '0';
        }

        // Convert to lower case.
        ch |= ' ';

        if (ch is >= 'a' and <= 'z')
        {
            return ch - 'a';
        }

        throw new InvalidTokenException("alphanumeric", index, ch);
    }

    /// <summary>
    /// Converts the character at the specified index in the buffer to its corresponding base-10 value.
    /// <para>
    ///     The mapping is as follows:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>'0'-'9' → 0-9</description>
    ///         </item>
    ///         <item>
    ///             <description>'A'-'I' (or 'a'-'i') → 1-9</description>
    ///         </item>
    ///         <item>
    ///             <description>'J'-'R' (or 'j'-'r') → 1-9</description>
    ///         </item>
    ///         <item>
    ///             <description>'S'-'Z' (or 's'-'z') → 2-9</description>
    ///         </item>
    ///     </list>
    /// </para>
    /// </summary>
    /// <param name="buffer">The buffer containing the character to convert. Must contain an alphanumeric character at the specified index.</param>
    /// <param name="index">The zero-based index of the character within the buffer.</param>
    /// <returns>An integer representing the base-10 value of the alphanumeric character at the specified index.</returns>
    /// <exception cref="InvalidTokenException">Thrown when the character at the specified index is not an alphanumeric character ('0'–'9', 'a'–'z', or 'A'–'Z').</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int GetAlphaNumericBase10Value(this Buffer buffer, int index)
    {
        char ch = buffer[index];
        if (ch is >= '0' and <= '9')
        {
            return ch - '0';
        }

        // Convert to lower case.
        ch |= ' ';

        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (ch is < 'a' or > 'z')
        {
            throw new InvalidTokenException("alphanumeric", index, ch);
        }

        // a = 1, b = 2, ..., i = 9
        if (ch <= 'i')
        {
            return ch - 'a' + 1;
        }

        // j = 1, k = 2, ..., r = 9
        if (ch <= 'r')
        {
            return ch - 'j' + 1;
        }

        // s = 2, t = 3, ..., z = 9
        return ch - 's' + 2;
    }
}
