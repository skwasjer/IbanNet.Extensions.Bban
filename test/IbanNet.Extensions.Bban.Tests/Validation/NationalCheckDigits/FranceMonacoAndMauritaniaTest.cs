namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class FranceMonacoAndMauritaniaTest
{
    private readonly FranceMonacoAndMauritania _sut = new();

    [Theory]
    [InlineData("30001007941234567890185")]
    [InlineData("30004000031234567890143")]
    [InlineData("30006000011234567890189")]
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("30001007941234567890186")]
    [InlineData("30004000031234567890144")]
    [InlineData("30006000011234567890190")]
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }
}
