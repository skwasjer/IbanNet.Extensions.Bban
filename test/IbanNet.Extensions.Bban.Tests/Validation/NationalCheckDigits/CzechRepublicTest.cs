namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class CzechRepublicTest
{
    private readonly CzechRepublic _sut = new();

    [Theory]
    [InlineData("00000000000000000000")]  // Bank: 0000, Prefix: 000000 (data "00000"+check 0), Account: 0000000000 (data "000000000"+check 0)
    [InlineData("01231234571234567899")]  // Bank: 0123, Prefix: 123457 (data "12345"+check 7), Account: 1234567899 (data "123456789"+check 9)
    [InlineData("99990000000000000000")]  // Bank: 9999, Prefix: 000000 (check 0), Account: 0000000000 (check 0)
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("00000000010000000000")]  // Invalid prefix check digit (1 instead of 0)
    [InlineData("00000000000000000001")]  // Invalid account check digit (1 instead of 0)
    [InlineData("01231234507123456789")]  // Invalid prefix check digit (0 instead of 7)
    [InlineData("01231234571234567890")]  // Invalid account check digit (0 instead of 9)
    [InlineData("00000000010000000001")]  // Both check digits invalid
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }
}
