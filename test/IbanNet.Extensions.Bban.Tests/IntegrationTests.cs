using FluentAssertions;
using IbanNet.Extensions.Bban.Validation.Results;
using IbanNet.Extensions.Bban.Validation.Rules;
using Xunit;

namespace IbanNet.Extensions.Bban;

public class IntegrationTests
{
    private readonly IbanValidator _validator;

    public IntegrationTests()
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
    [InlineData("IT07X0542811101000100123456")]
    [InlineData("SM24U0322509800010000270100")]
    [InlineData("NO4386012117947")]
    [InlineData("BA731290079401027494")]
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