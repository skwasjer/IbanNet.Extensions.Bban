namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public class Mod97NoZeroCheckDigitsCalculatorTest
{
    private readonly Mod97NoZeroCheckDigitsCalculator _sut;

    public Mod97NoZeroCheckDigitsCalculatorTest()
    {
        _sut = new Mod97NoZeroCheckDigitsCalculator();
    }

    [Theory]
    [InlineData("1234567890", 2)]
    [InlineData("0000000004", 4)]
    [InlineData("1234567888", 97)]
    [InlineData("5390075470", 34)]
    public void Given_account_number_when_computing_check_digit_should_match_expected(string accountNumber, int expectedCheckDigits)
    {
        // Act
        int actual = _sut.Compute(accountNumber.ToCharArray());

        // Assert
        actual.Should().Be(expectedCheckDigits);
    }
}