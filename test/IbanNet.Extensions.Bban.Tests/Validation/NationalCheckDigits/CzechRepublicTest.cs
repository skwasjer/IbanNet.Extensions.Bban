using IbanNet.Extensions.Bban.CheckDigits;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public static class CzechRepublicTest
{
    public sealed class PrefixTests
    {
        private readonly CzechRepublic.Prefix _sut = new();

        [Theory]
        [InlineData("00000000000000000000")] // Bank: 0000, Prefix: 000000 (data "00000"+check 0), Account: 0000000000 (data "000000000"+check 0)
        [InlineData("01231234571234567899")] // Bank: 0123, Prefix: 123457 (data "12345"+check 7), Account: 1234567899 (data "123456789"+check 9)
        [InlineData("99990000000000000000")] // Bank: 9999, Prefix: 000000 (check 0), Account: 0000000000 (check 0)
        public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
        {
            _sut.Validate(bban).Should().BeTrue();
        }

        [Theory]
        [InlineData("00000000010000000000")] // Invalid prefix check digit (1 instead of 0)
        [InlineData("01231234507123456789")] // Invalid prefix check digit (0 instead of 7)
        [InlineData("00000000010000000001")] // Both check digits invalid
        public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
        {
            _sut.Validate(bban).Should().BeFalse();
        }
    }

    public sealed class AccountTests
    {
        private readonly CzechRepublic.Account _sut = new();

        [Theory]
        [InlineData("00000000000000000000")] // Bank: 0000, Prefix: 000000 (data "00000"+check 0), Account: 0000000000 (data "000000000"+check 0)
        [InlineData("01231234571234567899")] // Bank: 0123, Prefix: 123457 (data "12345"+check 7), Account: 1234567899 (data "123456789"+check 9)
        [InlineData("99990000000000000000")] // Bank: 9999, Prefix: 000000 (check 0), Account: 0000000000 (check 0)
        public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
        {
            _sut.Validate(bban).Should().BeTrue();
        }

        [Theory]
        [InlineData("00000000000000000001")] // Invalid account check digit (1 instead of 0)
        [InlineData("01231234571234567890")] // Invalid account check digit (0 instead of 9)
        [InlineData("00000000010000000001")] // Both check digits invalid
        public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
        {
            _sut.Validate(bban).Should().BeFalse();
        }
    }

    public sealed class WeightedMod11AlgorithmTests
    {
        private static readonly int[] Weights = [1, 2, 3, 4];
        private readonly CzechRepublic.WeightedMod11Algorithm _sut = new(Weights);

        [Theory]
        [InlineData("0000", 0)] // sum = 0, rem = 0, check = 0
        [InlineData("1102", 0)] // sum = 1×1+1×2+0×3+2×4 = 11, rem = 11%11 = 0, check = 11-0 = 0
        [InlineData("1111", 1)] // sum = 1×1+1×2+1×3+1×4 = 10, rem = 10%11 = 10, check = 11-10 = 1
        [InlineData("3631", 5)] // sum = 3×1+6×2+3×3+1×4 = 28, rem = 28%11 = 6, check = 11-6 = 5
        [InlineData("1234", 3)] // sum = 1×1+2×2+3×3+4×4 = 30, rem = 30%11 = 8, check = 11-8 = 3
        [InlineData("9163", 3)] // sum = 9×1+1×2+6×3+3×4 = 41, rem = 41%11 = 8, check = 11-8 = 3
        public void It_should_return_expected(string input, int expectedResult)
        {
            _sut.Compute(input).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("000:", ':', 3)]
        [InlineData("0é00", 'é', 1)]
        [InlineData("00a0", 'a', 2)]
        [InlineData("B000", 'B', 0)]
        public void Given_that_input_contains_a_non_numeric_character_when_computing_it_should_throw(string value, char invalidChar, int errorPosition)
        {
            _sut.Invoking(s => s.Compute(value))
                .Should()
                .Throw<InvalidTokenException>()
                .WithMessage($"Expected numeric character at position {errorPosition}, but found '{invalidChar}'.");
        }

        [Theory]
        [InlineData("000")]
        [InlineData("000000")]
        public void Given_that_input_contains_the_wrong_number_of_chars_when_computing_it_should_throw(string buffer)
        {
            _sut.Invoking(s => s.Compute(buffer))
                .Should()
                .Throw<ArgumentException>()
                .WithMessage($"The input must be exactly {Weights.Length} digits for Czech validation.*")
                .WithParameterName(nameof(buffer));
        }
    }
}
