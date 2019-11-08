using FluentAssertions;
using Xunit;

namespace IbanNet.Validation.NationalCheckDigits
{
	public class CleRibNationalCheckDigitsValidatorTest
	{
		// FR, MR, MC
        [Theory]
		[InlineData("30001007941234567890185")]
		[InlineData("30004000031234567890143")]
		[InlineData("30006000011234567890189")]
		public void Given_valid_bban_should_validate(string bban)
		{
			var validator = new CleRibNationalCheckDigitsValidator();
            validator.Validate(bban).Should().BeTrue();
        }

        // FR, MR, MC
        [Theory]
		[InlineData("30001007941234567890186")]
		[InlineData("30004000031234567890144")]
		[InlineData("30006000011234567890190")]
		public void Given_invalid_bban_should_not_validate(string bban)
		{
			var validator = new CleRibNationalCheckDigitsValidator();
            validator.Validate(bban).Should().BeFalse();
		}
    }
}
