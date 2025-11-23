using IbanNet.Extensions.Bban.CheckDigits;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class PolandTest
{
    private readonly Poland _sut = new();

    [Theory]
    [InlineData("114020040000300201355387")] // From PL61 1140 2004 0000 3002 0135 5387
    [InlineData("102055581111000049151640")] // Another valid Polish BBAN
    [InlineData("000000000000000000000000")] // Edge case: all zeros with valid check digit
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("114020050000300201355387")] // Invalid check digit (5 instead of 4)
    [InlineData("102055591111000049151640")] // Invalid check digit (9 instead of 8)
    [InlineData("000000010000000000000000")] // Invalid check digit (1 instead of 0)
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }

    public sealed class WeightedMod10AlgorithmTests
    {
        private readonly Poland.WeightedMod10Algorithm _sut = new();

        [Theory]
        [InlineData("1140200", 4)] // From PL61 1140 2004 0000 3002 0135 5387
        [InlineData("0000000", 0)] // Edge case: all zeros
        [InlineData("1234567", 6)] // Additional test case: 1*3+2*9+3*7+4*1+5*3+6*9+7*7=164, 10-(164%10)=6
        public void It_should_return_expected(string input, int expectedResult)
        {
            _sut.Compute(input).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("000:000", ':', 3)]
        [InlineData("000000é", 'é', 6)]
        [InlineData("0000a00", 'a', 4)]
        [InlineData("B000000", 'B', 0)]
        public void Given_that_input_contains_a_non_numeric_character_when_computing_it_should_throw(string value, char invalidChar, int errorPosition)
        {
            _sut.Invoking(s => s.Compute(value))
                .Should()
                .Throw<InvalidTokenException>()
                .WithMessage($"Expected numeric character at position {errorPosition}, but found '{invalidChar}'.");
        }

        [Theory]
        [InlineData("000000")]
        [InlineData("00000000")]
       public void Given_that_input_contains_the_wrong_number_of_chars_when_computing_it_should_throw(string buffer)
        {
            _sut.Invoking(s => s.Compute(buffer))
                .Should()
                .Throw<ArgumentException>()
                .WithMessage($"The input '{buffer}' must be exactly 7 digits for Polish bank code validation.*")
                .WithParameterName(nameof(buffer));
        }
    }
}
