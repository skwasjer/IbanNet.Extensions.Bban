using IbanNet.Builders;
using IbanNet.Extensions.Bban.Validation.Results;
using IbanNet.Extensions.Bban.Validation.Rules;
using IbanNet.Registry;

namespace IbanNet.Extensions.Bban;

public class IntegrationTests
{
    private readonly IbanValidator _validator;

    public IntegrationTests()
    {
        _validator = new IbanValidator(new IbanValidatorOptions { Rules = { new HasValidNationalCheckDigitsRule() } });
    }

    [Theory]
    [InlineData("BE", "539007547034")]
    [InlineData("FR","20041010050500013M02606")]
    [InlineData("FR","30006000011234567890189")]
    [InlineData("MR","00020001010000123456753")]
    [InlineData("MC","11222000010123456789030")]
    [InlineData("IT","X0542811101000000123456")]
    [InlineData("SM","U0322509800000000270100")]
    [InlineData("NO","86011117947")]
    [InlineData("NO","00000100080")] // Mod 11 = 0
    [InlineData("BA","1290079401028494")]
    [InlineData("PL","114020040000300201355387")]
    [InlineData("FI","10093000123458")]
    [InlineData("CZ","01231234571234567899")]
    [InlineData("PT", "000201231234567890154")]
    public void Given_iban_with_valid_national_check_digits_when_validating_it_should_validate(string countryCode, string bban)
    {
        string iban = new IbanBuilder()
            .WithCountry(countryCode, IbanRegistry.Default)
            .WithBankAccountNumber(bban)
            .Build();

        // Act
        ValidationResult result = _validator.Validate(iban);

        // Assert
        result.Should().BeEquivalentTo(new ValidationResult { AttemptedValue = iban, Country = _validator.SupportedCountries[countryCode] });
    }

    [Theory]
    [InlineData("BE","539007547035")]
    [InlineData("FR","20041010050500013M02605")]
    [InlineData("FR","30006000011234567890188")]
    [InlineData("IT","X0542811101000100123456")]
    [InlineData("SM","U0322509800010000270100")]
    [InlineData("NO","86012117947")]
    [InlineData("NO","00000100030")] // Mod 11 = 1 (not valid, because the complement 11 - 1 = 10 (2 digits) and the account number only has 1 check digit)
    [InlineData("BA","1290079401027494")]
    [InlineData("PL","114020050000300201355387")]
    [InlineData("FI","10093000123459")]
    [InlineData("CZ","01231234501234567899")]
    [InlineData("PT", "000201231234567890155")]
    public void Given_iban_with_invalid_national_check_digits_when_validating_it_should_not_validate(string countryCode, string bban)
    {
        string iban = new IbanBuilder()
            .WithCountry(countryCode, IbanRegistry.Default)
            .WithBankAccountNumber(bban)
            .Build();

        // Act
        ValidationResult result = _validator.Validate(iban);

        // Assert
        result.Should()
        .BeEquivalentTo(new ValidationResult
        {
            AttemptedValue = iban,
            Country = _validator.SupportedCountries[countryCode],
            Error = new InvalidNationalCheckDigitsResult()
        });
    }
}
