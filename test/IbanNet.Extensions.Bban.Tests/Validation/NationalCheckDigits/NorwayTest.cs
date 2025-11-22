namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class NorwayTest
{
    private readonly Norway _sut = new();

    [Theory]
    [InlineData("12340012345")] // Contains 2 zeroes at pos 4 and 5.
    [InlineData("00000100080")] // Mod 11 = 0
    [InlineData("86011117947")]
    [InlineData("02056439652")]
    [InlineData("12345678903")]
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("00000100030")] // Mod 11 = 1 (not valid, because the complement 11 - 1 = 10 (2 digits) and the account number only has 1 check digit)
    [InlineData("02056439653")]
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }
}
