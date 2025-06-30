using FluentAssertions;
using Xunit;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public class CinNationalCheckDigitsValidatorTest
{
    //IT, SM
    [Theory]
    [InlineData("C0114962654315W0AV67Q9J")]
    [InlineData("I0900245288OKALSKMZQPVZ")]
    [InlineData("U9382566253RRP8KQG4ALJZ")]
    public void Given_valid_bban_should_validate(string bban)
    {
        var validator = new CinNationalCheckDigitsValidator();
        validator.Validate(bban).Should().BeTrue();
    }

    //IT, SM
    [Theory]
    [InlineData("V0114962654315W0AV67Q9J")]
    [InlineData("B0900245288OKALSKMZQPVZ")]
    [InlineData("L9382566253RRP8KQG4ALJZ")]
    public void Given_invalid_bban_should_not_validate(string bban)
    {
        var validator = new CinNationalCheckDigitsValidator();
        validator.Validate(bban).Should().BeFalse();
    }
}