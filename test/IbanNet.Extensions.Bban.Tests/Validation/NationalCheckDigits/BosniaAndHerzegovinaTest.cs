namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class BosniaAndHerzegovinaTest
{
    private readonly BosniaAndHerzegovina _sut = new();

    [Theory]
    [InlineData("1990440001200279")]
    [InlineData("1290079401028494")]
    [InlineData("0060000123456758")]
    [InlineData("0060000123458698")]
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("1990440001200278")]
    [InlineData("1290079401028493")]
    [InlineData("0060000123456757")]
    [InlineData("0060000123458697")]
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }
}
