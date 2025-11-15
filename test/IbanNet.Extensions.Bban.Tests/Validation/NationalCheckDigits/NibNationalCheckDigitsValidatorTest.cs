namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public class NibNationalCheckDigitsValidatorTest
{
    // BA
    [Theory]
    [InlineData("000201231234567890154")]
    [InlineData("123443211234567890172")]
    [InlineData("003507390002158210038")]
    [InlineData("003604569910448906182")]
    public void Given_valid_bban_should_validate(string bban)
    {
        var validator = new NibNationalCheckDigitsValidator();
        validator.Validate(bban).Should().BeTrue();
    }

    // BA
    [Theory]
    [InlineData("000201231234567890153")]
    [InlineData("123443211234567890171")]
    [InlineData("003507390002158210039")]
    [InlineData("003604569910448906183")]
    public void Given_invalid_bban_should_not_validate(string bban)
    {
        var validator = new NibNationalCheckDigitsValidator();
        validator.Validate(bban).Should().BeFalse();
    }
}