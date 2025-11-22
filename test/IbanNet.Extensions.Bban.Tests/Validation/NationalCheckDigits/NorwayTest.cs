using IbanNet.Extensions.Bban.CheckDigits;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class NorwayTest
{
    private readonly Norway _sut = new();

    [Theory]
    [InlineData("12340012345")] // Contains 2 zeroes at pos 4 and 5.
    [InlineData("00000100080")] // Mod 11 = 0
    [InlineData("86011117947")]
    [InlineData("02056439652")]
    [InlineData("12345678903")]
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("00000100030")] // Mod 11 = 1 (not valid, because the complement 11 - 1 = 10 (2 digits) and the account number only has 1 check digit)
    [InlineData("02056439653")]
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }

    public sealed class WeightedMod11AlgorithmTests
    {
        private readonly Norway.WeightedMod11Algorithm _sut = new();

        [Theory]
        [InlineData("0000010008", 0)]
        [InlineData("8601111794", 7)]
        [InlineData("0205643965", 2)]
        [InlineData("1234567890", 3)]
        public void It_should_return_expected(string input, int expectedResult)
        {
            _sut.Compute(input).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("000:000000", ':', 3)]
        [InlineData("000000é000", 'é', 6)]
        [InlineData("000000000a", 'a', 9)]
        [InlineData("B000000000", 'B', 0)]
        public void Given_that_input_contains_a_non_numeric_character_when_computing_it_should_throw(string value, char invalidChar, int errorPosition)
        {
            _sut.Invoking(s => s.Compute(value))
                .Should()
                .Throw<InvalidTokenException>()
                .WithMessage($"Expected numeric character at position {errorPosition}, but found '{invalidChar}'.");
        }
    }
}
