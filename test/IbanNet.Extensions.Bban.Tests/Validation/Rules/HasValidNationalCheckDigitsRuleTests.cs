using IbanNet.Extensions.Bban.CheckDigits.Algorithms;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;
using IbanNet.Extensions.Bban.Validation.Results;
using IbanNet.Registry;
using IbanNet.Registry.Patterns;
using IbanNet.Validation.Results;
using IbanNet.Validation.Rules;

namespace IbanNet.Extensions.Bban.Validation.Rules;

public class HasValidNationalCheckDigitsRuleTests
{
    private readonly HasValidNationalCheckDigitsRule _sut;
    private readonly NationalCheckDigitsValidator _checkDigitsValidatorMock;

    public HasValidNationalCheckDigitsRuleTests()
    {
        _checkDigitsValidatorMock = Substitute.ForPartsOf<NationalCheckDigitsValidator>(
            new CheckDigitsAlgorithmStub(123),
            Substitute.For<CheckString>(),
            Substitute.For<NationalCheckDigits.CheckDigits>(),
            "ZZ");

        var checkDigitValidatorStubs = new Dictionary<string, IEnumerable<NationalCheckDigitsValidator>> { { "ZZ", [_checkDigitsValidatorMock] } };

        _sut = new HasValidNationalCheckDigitsRule(checkDigitValidatorStubs);
    }

    [Fact]
    public void Given_that_context_is_null_when_validating_it_should_throw()
    {
        ValidationRuleContext? context = null;

        // Act
        Action act = () => _sut.Validate(context!);

        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .Which.ParamName.Should()
            .Be(nameof(context));
    }

    [Fact]
    public void Given_that_no_validator_matches_iban_country_when_validating_it_should_pass()
    {
        var context = new ValidationRuleContext("XX000000", new IbanCountry("XX"));

        // Act
        ValidationRuleResult actual = _sut.Validate(context);

        // Assert
        actual.Should().BeSameAs(ValidationRuleResult.Success);
        _checkDigitsValidatorMock
            .DidNotReceive()
            .Validate(Arg.Any<string>());
    }

    [Fact]
    public void Given_that_bban_structure_length_is_zero_when_validating_it_should_fail()
    {
        var context = new ValidationRuleContext("ZZ000000", new IbanCountry("ZZ") { Bban = new BbanStructure(new TestPattern([])) });

        // Act
        ValidationRuleResult actual = _sut.Validate(context);

        // Assert
        actual.Should().BeOfType<InvalidNationalCheckDigitsResult>();
        _checkDigitsValidatorMock
            .DidNotReceive()
            .Validate(Arg.Any<string>());
    }

    [Theory]
    [InlineData(0, 10)]
    [InlineData(5, 6)]
    public void Given_that_bban_expected_length_is_greater_than_available_when_validating_it_should_fail(int position, int length)
    {
        var context = new ValidationRuleContext("ZZ000000",
            new IbanCountry("ZZ")
            {
                Bban = new BbanStructure(
                    new TestPattern([new PatternToken(AsciiCategory.Digit, length)]),
                    position)
            });

        // Act
        ValidationRuleResult actual = _sut.Validate(context);

        // Assert
        actual.Should().BeOfType<InvalidNationalCheckDigitsResult>();
        _checkDigitsValidatorMock
            .DidNotReceive()
            .Validate(Arg.Any<string>());
    }

    [Theory]
    [InlineData(2, 7, "0123456")]
    [InlineData(4, 4, "2345")]
    public void When_validating_it_should_extract_bban_from_iban(int position, int length, string expectedExtractedBban)
    {
        var context = new ValidationRuleContext("ZZ0123456",
            new IbanCountry("ZZ")
            {
                Bban = new BbanStructure(
                    new TestPattern([new PatternToken(AsciiCategory.Digit, length)]),
                    position)
            });

        // Act
        _sut.Validate(context);

        // Assert
        _checkDigitsValidatorMock
            .Received(1)
            .Validate(expectedExtractedBban);
    }

    [Fact]
    public void Given_multiple_check_digit_validators_when_validating_it_should_only_use_those_that_have_matching_country()
    {
        var matchingCheckDigitValidatorMock = Substitute.ForPartsOf<NationalCheckDigitsValidator>(
            new CheckDigitsAlgorithmStub(123),
            Substitute.For<CheckString>(),
            Substitute.For<NationalCheckDigits.CheckDigits>(),
            "WW"
        );

        var checkDigitValidatorStubs = new Dictionary<string, IEnumerable<NationalCheckDigitsValidator>> { { "ZZ", [_checkDigitsValidatorMock] }, { "WW", [matchingCheckDigitValidatorMock] } };

        matchingCheckDigitValidatorMock
            .Validate(Arg.Any<string>())
            .Returns(true);

        var sut = new HasValidNationalCheckDigitsRule(checkDigitValidatorStubs);

        var context = new ValidationRuleContext("WW0123456",
            new IbanCountry("WW")
            {
                Bban = new BbanStructure(
                    new TestPattern([new PatternToken(AsciiCategory.Digit, 7)]),
                    2)
            });

        // Act
        ValidationRuleResult actual = sut.Validate(context);

        // Assert
        actual.Should().BeSameAs(ValidationRuleResult.Success);
        matchingCheckDigitValidatorMock.Received(1).Validate(Arg.Any<string>());
        _checkDigitsValidatorMock.DidNotReceive().Validate(Arg.Any<string>());
    }

    [Theory]
    [InlineData(false, false, false)]
    [InlineData(true, false, false)]
    [InlineData(false, true, false)]
    [InlineData(true, true, true)]
    public void Given_multiple_check_digit_validators_matching_the_country_when_validating_it_should_validate_using_all(bool matchesFirst, bool matchesSecond, bool shouldBeValid)
    {
        var checkDigitValidatorStubs = new Dictionary<string, IEnumerable<NationalCheckDigitsValidator>> { { "ZZ", [_checkDigitsValidatorMock, _checkDigitsValidatorMock] } };

        _checkDigitsValidatorMock
            .Validate(Arg.Any<string>())
            .Returns(matchesFirst, matchesSecond);

        var sut = new HasValidNationalCheckDigitsRule(checkDigitValidatorStubs);

        var context = new ValidationRuleContext("ZZ0123456",
            new IbanCountry("ZZ")
            {
                Bban = new BbanStructure(
                    new TestPattern([new PatternToken(AsciiCategory.Digit, 7)]),
                    2)
            });

        // Act
        ValidationRuleResult actual = sut.Validate(context);

        // Assert
        if (shouldBeValid)
        {
            actual.Should().BeSameAs(ValidationRuleResult.Success);
        }
        else
        {
            actual.Should().BeOfType<InvalidNationalCheckDigitsResult>();
        }

        _checkDigitsValidatorMock.Received(!matchesFirst ? 1 : 2).Validate(Arg.Any<string>());
    }

    [Fact]
    public void Given_null_validators_when_creating_it_should_throw()
    {
        Dictionary<string, IEnumerable<NationalCheckDigitsValidator>>? nationalCheckDigitsValidators = null;

        // Act
        Func<HasValidNationalCheckDigitsRule> act = () => new HasValidNationalCheckDigitsRule(nationalCheckDigitsValidators!);

        // Assert
        act.Should()
            .Throw<ArgumentNullException>()
            .Which.ParamName.Should()
            .Be(nameof(nationalCheckDigitsValidators));
    }
}
