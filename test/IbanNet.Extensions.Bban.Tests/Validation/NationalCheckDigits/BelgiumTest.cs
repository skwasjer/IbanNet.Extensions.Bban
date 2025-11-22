namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class BelgiumTest
{
    private readonly Belgium _sut = new();

    [Theory]
    [InlineData("123456789002")]
    [InlineData("000000000404")]
    [InlineData("123456788897")]
    [InlineData("539007547034")]
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("123456789003")]
    [InlineData("000000000402")]
    [InlineData("123456788800")]
    [InlineData("539007547033")]
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }
}
