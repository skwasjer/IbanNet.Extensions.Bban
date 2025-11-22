namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class PortugalTest
{
    private readonly Portugal _sut = new();

    [Theory]
    [InlineData("000201231234567890154")]
    [InlineData("123443211234567890172")]
    [InlineData("003507390002158210038")]
    [InlineData("003604569910448906182")]
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    // BA
    [Theory]
    [InlineData("000201231234567890153")]
    [InlineData("123443211234567890171")]
    [InlineData("003507390002158210039")]
    [InlineData("003604569910448906183")]
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }
}
