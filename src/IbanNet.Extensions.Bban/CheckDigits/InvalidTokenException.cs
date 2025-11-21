namespace IbanNet.Extensions.Bban.CheckDigits;

/// <summary>
/// Exception that is thrown when an unexpected token/character is encountered while computing check digits.
/// </summary>
internal sealed class InvalidTokenException : InvalidOperationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTokenException" />.
    /// </summary>
    public InvalidTokenException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTokenException" /> using specified message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public InvalidTokenException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTokenException" /> class using specified message and inner exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The inner exception.</param>
    public InvalidTokenException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTokenException" /> using specified <paramref name="position" /> and the character that was not expected.
    /// </summary>
    /// <param name="type">The type of character (eg. alphanumeric or numeric)</param>
    /// <param name="position">The position in the string/char buffer where the unexpected character is located.</param>
    /// <param name="unexpectedChar">The character that was not expected.</param>
    public InvalidTokenException(string type, int position, char unexpectedChar)
        : this($"Expected {type} character at position {position}, but found '{unexpectedChar}'.")
    {
    }
}
