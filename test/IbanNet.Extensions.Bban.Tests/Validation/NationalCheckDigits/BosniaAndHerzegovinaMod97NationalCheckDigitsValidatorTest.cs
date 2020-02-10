using FluentAssertions;
using Xunit;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits
{
    public class BosniaAndHerzegovinaMod97NationalCheckDigitsValidatorTest
    {
        // BA
        [Theory]
        [InlineData("1990440001200279")]
        [InlineData("1290079401028494")]
        [InlineData("0060000123456758")]
        [InlineData("0060000123458698")]
        public void Given_valid_bban_should_validate(string bban)
        {
            var validator = new BosniaAndHerzegovinaMod97NationalCheckDigitsValidator();
            validator.Validate(bban).Should().BeTrue();
        }

        // BA
        [Theory]
        [InlineData("1990440001200278")]
        [InlineData("1290079401028493")]
        [InlineData("0060000123456757")]
        [InlineData("0060000123458697")]
        public void Given_invalid_bban_should_not_validate(string bban)
        {
            var validator = new BosniaAndHerzegovinaMod97NationalCheckDigitsValidator();
            validator.Validate(bban).Should().BeFalse();
        }
    }
}
