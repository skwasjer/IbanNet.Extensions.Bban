using System;
using FluentAssertions;
using IbanNet.CheckDigits.Calculators;
using Xunit;

namespace IbanNet.Extensions.Bban.CheckDigits.Calculators
{
    public class InverseWeightedMod11CheckDigitsCalculatorTests
    {
        private readonly InverseWeightedMod11CheckDigitsCalculator _sut;

        public InverseWeightedMod11CheckDigitsCalculatorTests()
        {
            _sut = new InverseWeightedMod11CheckDigitsCalculator();
        }

        [Theory]
        [InlineData(11)]
        [InlineData(50)]
        public void Given_input_value_is_longer_than_10_chars_when_computing_check_digit_it_should_throw(int length)
        {
            var value = new char[length];

            // Act
            Action act = () => _sut.Compute(value);

            // Assert
            act.Should()
                .Throw<ArgumentOutOfRangeException>()
                .Which.ParamName.Should()
                .Be(nameof(value));
        }

        [Theory]
        [InlineData("0000000000", 0)]
        [InlineData("0000000001", 1)]
        [InlineData("0000000020", 4)]
        [InlineData("0000000300", 9)]
        [InlineData("0000004000", 5)]
        [InlineData("0000050000", 3)]
        [InlineData("0000600000", 3)]
        [InlineData("0007000000", 5)]
        [InlineData("0080000000", 9)]
        [InlineData("0900000000", 4)]
        [InlineData("1000000000", 10)]
        [InlineData("1234567891", 2)]
        public void Given_input_value_when_computing_check_digit_it_should_return_expected_value(string input, int expectedCheckDigit)
        {
            // Act
            int actual = _sut.Compute(input.ToCharArray());

            // Assert
            actual.Should().Be(expectedCheckDigit);
        }

        [Theory]
        [InlineData("300", 9)]
        [InlineData("50351", 1)]
        public void Given_input_value_is_shorter_when_computing_check_digit_it_should_offset_and_return_expected_value(string input, int expectedCheckDigit)
        {
            // Act
            int actual = _sut.Compute(input.ToCharArray());

            // Assert
            actual.Should().Be(expectedCheckDigit);
        }

        [Fact]
        public void Given_that_input_contains_non_digit_when_computing_it_should_throw()
        {
            const string input = "01234X6789";

            // Act
            Action act = () => _sut.Compute(input.ToCharArray());

            // Assert
            act.Should()
                .Throw<InvalidTokenException>()
                .WithMessage("Expected digit at position 5, but found 'X'.");
        }
    }
}
