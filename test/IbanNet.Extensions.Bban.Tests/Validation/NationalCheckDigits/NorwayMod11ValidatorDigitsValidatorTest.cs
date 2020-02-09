using FluentAssertions;
using Xunit;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits
{
	public class NorwayMod11ValidatorDigitsValidatorTest
	{
		// NO
        [Theory]
		[InlineData("12340012345")]
		[InlineData("12340012346")]
		[InlineData("12340012347")]
		public void Given_a_double_zero_bban_should_validate(string bban)
		{
			var validator = new NorwayMod11ValidatorDigitsValidator();
            validator.Validate(bban).Should().BeTrue();
        }

        // NO
        [Theory]
		[InlineData("86011117947")]
		[InlineData("02056439652")]
		[InlineData("12345678903")]
		public void Given_valid_bban_should_validate(string bban)
		{
			var validator = new NorwayMod11ValidatorDigitsValidator();
            validator.Validate(bban).Should().BeTrue();
		}

        // NO
        [Theory]
		[InlineData("02056439653")]
		public void Given_invalid_bban_should_not_validate(string bban)
		{
			var validator = new NorwayMod11ValidatorDigitsValidator();
            validator.Validate(bban).Should().BeFalse();
		}
    }
}
