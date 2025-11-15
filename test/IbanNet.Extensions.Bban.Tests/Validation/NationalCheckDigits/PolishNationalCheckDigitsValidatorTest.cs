namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public class PolishNationalCheckDigitsValidatorTest
{
    [Theory]
    [InlineData("114020040000300201355387")]  // From PL61 1140 2004 0000 3002 0135 5387
    [InlineData("102055581111000049151640")]  // Another valid Polish BBAN
    [InlineData("000000000000000000000000")]  // Edge case: all zeros with valid check digit
    public void Given_valid_bban_should_validate(string bban)
    {
        var validator = new PolishNationalCheckDigitsValidator();
        validator.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("114020050000300201355387")]  // Invalid check digit (5 instead of 4)
    [InlineData("102055591111000049151640")]  // Invalid check digit (9 instead of 8)
    [InlineData("000000010000000000000000")]  // Invalid check digit (1 instead of 0)
    public void Given_invalid_bban_should_not_validate(string bban)
    {
        var validator = new PolishNationalCheckDigitsValidator();
        validator.Validate(bban).Should().BeFalse();
    }
}
