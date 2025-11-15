namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public class FinnishNationalCheckDigitsValidatorTest
{
    [Theory]
    [InlineData("10093000123458")]  // From IBAN FI1410093000123458
    [InlineData("12345678901237")]  // Valid BBAN
    [InlineData("00000000000000")]  // Edge case: all zeros with valid check digit
    public void Given_valid_bban_should_validate(string bban)
    {
        var validator = new FinnishNationalCheckDigitsValidator();
        validator.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("10093000123459")]  // Invalid check digit (9 instead of 8)
    [InlineData("12345678901230")]  // Invalid check digit (0 instead of 7)
    [InlineData("00000000000001")]  // Invalid check digit (1 instead of 0)
    public void Given_invalid_bban_should_not_validate(string bban)
    {
        var validator = new FinnishNationalCheckDigitsValidator();
        validator.Validate(bban).Should().BeFalse();
    }
}
