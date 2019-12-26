using FluentAssertions;
using Xunit;

namespace IbanNet.Validation.NationalCheckDigits
{
    public class BelgiumMod97NationalCheckDigitsValidatorTest
    {
        // BE
        [Theory]
        [InlineData("123456789002")]
        [InlineData("000000000404")]
        [InlineData("123456788897")]
        [InlineData("539007547034")]
        public void Given_valid_bban_should_validate(string bban)
        {
            var validator = new BelgiumMod97NationalCheckDigitsValidator();
            validator.Validate(bban).Should().BeTrue();
        }

        // BE
        [Theory]
        [InlineData("123456789003")]
        [InlineData("000000000402")]
        [InlineData("123456788800")]
        [InlineData("539007547033")]
        public void Given_invalid_bban_should_not_validate(string bban)
        {
            var validator = new BelgiumMod97NationalCheckDigitsValidator();
            validator.Validate(bban).Should().BeFalse();
        }
    }
}
