namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public class LuhnAlgorithmTests
{
    private readonly LuhnAlgorithm _sut;

    public LuhnAlgorithmTests()
    {
        _sut = new LuhnAlgorithm();
    }

    [Theory]
    [InlineData("1009300012345", 8)]  // From IBAN FI1410093000123458
    [InlineData("1234567890123", 7)]  // Test case
    [InlineData("0000000000000", 0)]  // Edge case: all zeros
    [InlineData("1990000777770", 9)]  // Test case
    public void Given_first_thirteen_digits_when_computing_check_digit_should_match_expected(string firstThirteenDigits, int expectedCheckDigit)
    {
        // Act
        int actual = _sut.Compute(firstThirteenDigits);

        // Assert
        actual.Should().Be(expectedCheckDigit);
    }

    [Fact]
    public void Given_non_numeric_input_when_computing_should_throw_InvalidTokenException()
    {
        // Arrange
        const string invalidInput = "ABC1234567890";

        // Act & Assert
        _sut.Invoking(c => c.Compute(invalidInput))
            .Should().Throw<InvalidTokenException>()
            .WithMessage("*numeric*");
    }

    [Theory]
    [InlineData("123456789012")]   // Too short (12 digits)
    [InlineData("12345678901234")] // Too long (14 digits)
    public void Given_invalid_length_when_computing_should_throw_InvalidTokenException(string invalidInput)
    {
        // Act & Assert
        _sut.Invoking(c => c.Compute(invalidInput))
            .Should().Throw<InvalidTokenException>()
            .WithMessage("*13 digits*");
    }
}
