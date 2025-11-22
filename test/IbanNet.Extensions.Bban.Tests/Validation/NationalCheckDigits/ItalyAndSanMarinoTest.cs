namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public sealed class ItalyAndSanMarinoTest
{
    private readonly ItalyAndSanMarino _sut = new();

    [Theory]
    [InlineData("C0114962654315W0AV67Q9J")]
    [InlineData("I0900245288OKALSKMZQPVZ")]
    [InlineData("U9382566253RRP8KQG4ALJZ")]
    public void Given_that_bban_is_valid_when_validating_it_should_pass(string bban)
    {
        _sut.Validate(bban).Should().BeTrue();
    }

    [Theory]
    [InlineData("V0114962654315W0AV67Q9J")]
    [InlineData("B0900245288OKALSKMZQPVZ")]
    [InlineData("L9382566253RRP8KQG4ALJZ")]
    public void Given_that_bban_is_invalid_when_validating_it_should_fail(string bban)
    {
        _sut.Validate(bban).Should().BeFalse();
    }
}
