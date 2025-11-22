namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public sealed class LuhnAlgorithmTests
{
    private readonly LuhnAlgorithm _sut = new();

    [Theory]
    [InlineData("1789372997", 4)] // From Wikipedia
    [InlineData("1009300012345", 8)] // From IBAN FI1410093000123458
    [InlineData("1234567890123", 7)] // Test case
    [InlineData("0000000000000", 0)] // Edge case: all zeros
    [InlineData("1990000777770", 9)] // Test case
    [InlineData("937541841561453546570540148077931", 9)] // Long number
    public void It_should_return_expected(string input, int expectedResult)
    {
        _sut.Compute(input).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("123:5123451234567891", ':', 3)]
    [InlineData("123451234512345é7891", 'é', 15)]
    [InlineData("123451234a1234567891", 'a', 9)]
    [InlineData("B2345123451234567891", 'B', 0)]
    public void Given_that_input_contains_a_non_numeric_character_when_computing_it_should_throw(string value, char invalidChar, int errorPosition)
    {
        _sut.Invoking(s => s.Compute(value))
            .Should()
            .Throw<InvalidTokenException>()
            .WithMessage($"Expected numeric character at position {errorPosition}, but found '{invalidChar}'.");
    }
}
