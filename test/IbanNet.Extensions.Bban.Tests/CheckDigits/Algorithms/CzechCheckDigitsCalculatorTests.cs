using IbanNet.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public class CzechCheckDigitsCalculatorTests
{
    [Theory]
    [InlineData("000000", 0)]   // sum = 0, rem = 0, check = 0
    [InlineData("000001", 10)]  // sum = 0×10+0×5+0×8+0×4+0×2+1×1 = 1, rem = 1, check = 11-1 = 10
    [InlineData("000009", 2)]   // sum = 0×10+0×5+0×8+0×4+0×2+9×1 = 9, rem = 9, check = 11-9 = 2
    [InlineData("123450", 7)]   // sum = 1×10+2×5+3×8+4×4+5×2+0×1 = 10+10+24+16+10+0 = 70, rem = 70%11 = 4, check = 11-4 = 7
    public void Given_account_prefix_when_computing_check_digit_should_match_expected(string prefix, int expectedCheckDigit)
    {
        // Act
        int actual = CzechCheckDigitsCalculator.ComputePrefixCheckDigit(prefix.ToCharArray());

        // Assert
        actual.Should().Be(expectedCheckDigit);
    }

    [Theory]
    [InlineData("0000000000", 0)]   // sum = 0, rem = 0, check = 0
    [InlineData("0000000001", 10)]  // sum = 0+0+0+0+0+0+0+0+0+1×1 = 1, rem = 1, check = 11-1 = 10
    [InlineData("0000000009", 2)]   // sum = 9×1 = 9, rem = 9, check = 11-9 = 2
    [InlineData("1234567890", 9)]   // sum = 1×6+2×3+3×7+4×9+5×10+6×5+7×8+8×4+9×2+0×1 = 255, rem = 255%11 = 2, check = 11-2 = 9
    public void Given_account_number_when_computing_check_digit_should_match_expected(string accountNumber, int expectedCheckDigit)
    {
        // Act
        int actual = CzechCheckDigitsCalculator.ComputeAccountCheckDigit(accountNumber.ToCharArray());

        // Assert
        actual.Should().Be(expectedCheckDigit);
    }

    [Fact]
    public void Given_non_numeric_prefix_when_computing_should_throw_InvalidTokenException()
    {
        // Arrange
        char[] invalidInput = "ABC123".ToCharArray();

        // Act
        Action act = () => CzechCheckDigitsCalculator.ComputePrefixCheckDigit(invalidInput);

        // Assert
        act.Should().Throw<InvalidTokenException>()
            .WithMessage("*numeric*");
    }

    [Fact]
    public void Given_non_numeric_account_when_computing_should_throw_InvalidTokenException()
    {
        // Arrange
        char[] invalidInput = "ABCDEF1234".ToCharArray();

        // Act
        Action act = () => CzechCheckDigitsCalculator.ComputeAccountCheckDigit(invalidInput);

        // Assert
        act.Should().Throw<InvalidTokenException>()
            .WithMessage("*numeric*");
    }

    [Theory]
    [InlineData("12345")]   // Too short (5 digits)
    [InlineData("1234567")] // Too long (7 digits)
    public void Given_invalid_prefix_length_when_computing_should_throw_InvalidTokenException(string invalidInput)
    {
        // Act
        Action act = () => CzechCheckDigitsCalculator.ComputePrefixCheckDigit(invalidInput.ToCharArray());

        // Assert
        act.Should().Throw<InvalidTokenException>()
            .WithMessage("*6 digits*");
    }

    [Theory]
    [InlineData("123456789")]    // Too short (9 digits)
    [InlineData("12345678901")]  // Too long (11 digits)
    public void Given_invalid_account_length_when_computing_should_throw_InvalidTokenException(string invalidInput)
    {
        // Act
        Action act = () => CzechCheckDigitsCalculator.ComputeAccountCheckDigit(invalidInput.ToCharArray());

        // Assert
        act.Should().Throw<InvalidTokenException>()
            .WithMessage("*10 digits*");
    }
}
