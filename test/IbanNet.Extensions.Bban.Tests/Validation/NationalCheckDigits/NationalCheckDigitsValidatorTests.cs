using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public class NationalCheckDigitsValidatorTests
{
    private const string IbanTestValue = "some_fake_value";
    private const string CheckStringTestValue = "fake_value";
    private const int FakeCheckDigits = 12;

    private readonly CheckDigitsAlgorithmStub _checkDigitsAlgorithmMock;
    private readonly CheckString _getCheckStringFuncMock;
    private readonly CheckDigits _getCheckDigitsFuncMock;
    private readonly NationalCheckDigitsValidator _sut;

    public NationalCheckDigitsValidatorTests()
    {
        _checkDigitsAlgorithmMock = new CheckDigitsAlgorithmStub(FakeCheckDigits);

        _getCheckStringFuncMock = Substitute.For<CheckString>();
        _getCheckDigitsFuncMock = Substitute.For<CheckDigits>();

        _sut = Substitute.ForPartsOf<NationalCheckDigitsValidator>(_checkDigitsAlgorithmMock, _getCheckStringFuncMock, _getCheckDigitsFuncMock);

        _getCheckStringFuncMock
            .Invoke(Arg.Any<string>())
            .Returns(CheckStringTestValue);
    }

    [Fact]
    public void It_should_call_algorithm_with_checkstring_and_validate()
    {
        _getCheckDigitsFuncMock
            .Invoke(Arg.Any<string>())
            .Returns(FakeCheckDigits);

        // Act
        bool actual = _sut.Validate(IbanTestValue);

        // Assert
        actual.Should().BeTrue();
        _getCheckStringFuncMock
            .Received(1)
            .Invoke(IbanTestValue);
        _getCheckDigitsFuncMock
            .Received(1)
            .Invoke(IbanTestValue);
        _checkDigitsAlgorithmMock
            .Received.Should()
            .BeEquivalentTo(CheckStringTestValue);
    }

    public static IEnumerable<object[]> ShouldNotThrowExceptionCases()
    {
        yield return [new InvalidTokenException("error")];
        yield return [new ArgumentException("error")];
    }

    [Theory]
    [MemberData(nameof(ShouldNotThrowExceptionCases))]
    public void Given_that_algorithm_throws_exception_that_can_be_handled_when_validating_it_should_not_throw(Exception ex)
    {
        _checkDigitsAlgorithmMock.Throws(ex);

        // Act
        bool? actual = null;
        Action act = () => actual = _sut.Validate(IbanTestValue);

        // Assert
        act.Should().NotThrow();
        actual.Should().BeFalse();
        _checkDigitsAlgorithmMock
            .Received.Should()
            .BeEquivalentTo(CheckStringTestValue);
    }

    [Fact]
    public void Given_that_algorithm_throws_exception_that_can_not_be_handled_when_validating_it_should_throw()
    {
        var someExceptionNotHandled = new IOException();
        _checkDigitsAlgorithmMock.Throws(someExceptionNotHandled);

        // Act
        bool? actual = null;
        Action act = () => actual = _sut.Validate(IbanTestValue);

        // Assert
        act.Should()
            .Throw<IOException>()
            .Which.Should()
            .Be(someExceptionNotHandled);
        actual.Should().BeNull();
        _checkDigitsAlgorithmMock
            .Received.Should()
            .BeEquivalentTo(CheckStringTestValue);
    }
}
