namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class FinlandTest
{
    private readonly Finland _sut = new Finland();

    [Theory]
    [InlineData("10093000123458")]  // From IBAN FI1410093000123458
    [InlineData("12345678901237")]  // Valid BBAN
    [InlineData("00000000000000")]  // Edge case: all zeros with valid check digit
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("10093000123459")]  // Invalid check digit (9 instead of 8)
    [InlineData("12345678901230")]  // Invalid check digit (0 instead of 7)
    [InlineData("00000000000001")]  // Invalid check digit (1 instead of 0)
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }
}
