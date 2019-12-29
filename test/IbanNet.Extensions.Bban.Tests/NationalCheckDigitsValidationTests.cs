using FluentAssertions;
using IbanNet.Validation.Results;
using IbanNet.Validation.Rules;
using Xunit;

namespace IbanNet
{
	public class NationalCheckDigitsValidationTests
	{
		private readonly IbanValidator _validator;

        public NationalCheckDigitsValidationTests()
        {
            _validator = new IbanValidator(new IbanValidatorOptions
			{
				Rules =
				{
					new HasValidNationalCheckDigitsRule()
				}
			});
		}

        [Theory]
		[InlineData("FR1420041010050500013M02606")]
		[InlineData("FR7630006000011234567890189")]
		[InlineData("MR1300020001010000123456753")]
		[InlineData("MC5811222000010123456789030")]
		[InlineData("IT60X0542811101000000123456")]
		[InlineData("SM86U0322509800000000270100")]
		[InlineData("NO9386011117947")]
		[InlineData("BA391290079401028494")]
		public void Given_iban_with_valid_national_check_digits_when_validating_it_should_validate(string ibanWithNationalCheckDigits)
		{
			string countryCode = ibanWithNationalCheckDigits.Substring(0, 2);

			// Act
			ValidationResult result = _validator.Validate(ibanWithNationalCheckDigits);

			// Assert
			result.Should().BeEquivalentTo(new ValidationResult
			{
				AttemptedValue = ibanWithNationalCheckDigits,
				Country = _validator.SupportedCountries[countryCode]
			});
		}

        [Theory]
		[InlineData("FR4120041010050500013M02605")]
		[InlineData("FR0630006000011234567890188")]
		public void Given_iban_with_invalid_national_check_digits_when_validating_it_should_not_validate(string ibanWithTamperedNationalCheckDigits)
		{
			string countryCode = ibanWithTamperedNationalCheckDigits.Substring(0, 2);

			// Act
			ValidationResult result = _validator.Validate(ibanWithTamperedNationalCheckDigits);

			// Assert
			result.Should().BeEquivalentTo(new ValidationResult
			{
                AttemptedValue = ibanWithTamperedNationalCheckDigits,
				Country = _validator.SupportedCountries[countryCode],
				Error = new InvalidNationalCheckDigitsResult()
			});
		}
	}
}
