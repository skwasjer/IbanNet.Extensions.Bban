using FluentAssertions;
using Xunit;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits
{
    public class DutchNationalCheckDigitsValidatorTests
    {
        private readonly DutchNationalCheckDigitsValidator _sut;

        public DutchNationalCheckDigitsValidatorTests()
        {
            _sut = new DutchNationalCheckDigitsValidator();
        }

        [Theory]
        [InlineData("ABNA0417164300")]
        [InlineData("ABNA0726572756")]
        [InlineData("ASRB0480066884")]
        [InlineData("INGB0867974249")]
        public void Given_bban_with_valid_checkDigit_when_validating_it_should_pass(string validBban)
        {
            // Act
            bool actual = _sut.Validate(validBban);

            // Assert
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData("INGB0000026500")]
        [InlineData("INGB0010734510")]
        public void Given_bban_with_invalid_checkDigit_when_bankCode_is_on_exception_list_it_should_still_pass(string bbanWithInvalidCheckDigit)
        {
            // Act
            bool actual = _sut.Validate(bbanWithInvalidCheckDigit);

            // Assert
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData("ABNA0417164301")]
        [InlineData("ASRB0480066883")]
        [InlineData("ABNA0010734510")]
        public void Given_bban_with_invalid_checkDigit_when_bankCode_is_not_on_exception_list_it_should_fail(string bbanWithInvalidCheckDigit)
        {
            // Act
            bool actual = _sut.Validate(bbanWithInvalidCheckDigit);

            // Assert
            actual.Should().BeFalse();
        }
    }
}
