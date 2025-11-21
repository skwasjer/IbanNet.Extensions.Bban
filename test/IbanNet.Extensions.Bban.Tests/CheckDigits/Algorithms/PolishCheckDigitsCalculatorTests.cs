namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public class PolishCheckDigitsCalculatorTests
{
    private readonly PolishCheckDigitsCalculator _sut;

    public PolishCheckDigitsCalculatorTests()
    {
        _sut = new PolishCheckDigitsCalculator();
    }

    [Theory]
    [InlineData("1140200", 4)]  // From PL61 1140 2004 0000 3002 0135 5387
    [InlineData("0000000", 0)]  // Edge case: all zeros
    [InlineData("1234567", 6)]  // Additional test case: 1*3+2*9+3*7+4*1+5*3+6*9+7*7=164, 10-(164%10)=6
    public void Given_bank_code_when_computing_check_digit_should_match_expected(string bankCode, int expectedCheckDigit)
    {
        // Act
        int actual = _sut.Compute(bankCode);

        // Assert
        actual.Should().Be(expectedCheckDigit);
    }

    [Fact]
    public void Given_non_numeric_input_when_computing_should_throw_InvalidTokenException()
    {
        // Arrange
        const string invalidInput = "ABC1234";

        // Act & Assert
        _sut.Invoking(c => c.Compute(invalidInput))
            .Should().Throw<InvalidTokenException>()
            .WithMessage("*numeric*");
    }
}
