using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using IbanNet.CheckDigits.Calculators;
using Moq;
using Xunit;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public class NationalCheckDigitsValidatorTests
{
    const string IbanTestValue = "some_fake_value";
    const string CheckStringTestValue = "fake_value";

    private readonly Mock<ICheckDigitsCalculator> _checkDigitsCalculatorMock;
    private readonly Mock<NationalCheckDigitsValidator> _stub;
    private readonly Mock<CheckString> _getCheckStringFuncMock;
    private readonly Mock<CheckDigits> _getCheckDigitsFuncMock;
    private readonly NationalCheckDigitsValidator _sut;

    public NationalCheckDigitsValidatorTests()
    {
        _checkDigitsCalculatorMock = new Mock<ICheckDigitsCalculator>();

        _getCheckStringFuncMock = new Mock<CheckString>();
        _getCheckDigitsFuncMock = new Mock<CheckDigits>();

        _stub = new Mock<NationalCheckDigitsValidator>(_checkDigitsCalculatorMock.Object, _getCheckStringFuncMock.Object, _getCheckDigitsFuncMock.Object) { CallBase = true };

        _getCheckStringFuncMock
            .Setup(m => m.Invoke(It.IsAny<string>()))
            .Returns(CheckStringTestValue);

        _sut = _stub.Object;
    }

    [Fact]
    public void It_should_call_calculator_with_checkstring_and_validate()
    {
        _getCheckDigitsFuncMock
            .Setup(m => m.Invoke(It.IsAny<string>()))
            .Returns(123)
            .Verifiable();

        _checkDigitsCalculatorMock
            .Setup(m => m.Compute(It.Is<char[]>(ch => ch.SequenceEqual(CheckStringTestValue))))
            .Returns(123)
            .Verifiable();

        // Act
        bool actual = _sut.Validate(IbanTestValue);

        // Assert
        actual.Should().BeTrue();
        _stub.Verify();
        _getCheckStringFuncMock.Verify(m => m.Invoke(IbanTestValue), Times.Once);
        _getCheckDigitsFuncMock.Verify();
        _checkDigitsCalculatorMock.Verify();
    }

    public static IEnumerable<object[]> ShouldNotThrowExceptionCases()
    {
        yield return [new InvalidTokenException("error")];
        yield return [new ArgumentException("error")];
    }

    [Theory]
    [MemberData(nameof(ShouldNotThrowExceptionCases))]
    public void Given_calculator_throws_exception_that_can_be_handled_when_validating_it_should_not_throw(Exception ex)
    {
        _checkDigitsCalculatorMock
            .Setup(m => m.Compute(It.IsAny<char[]>()))
            .Throws(ex)
            .Verifiable();

        // Act
        bool? actual = null;
        Action act = () => actual = _sut.Validate(IbanTestValue);

        // Assert
        act.Should().NotThrow();
        actual.Should().BeFalse();
        _checkDigitsCalculatorMock.Verify();
    }

    [Fact]
    public void Given_calculator_throws_exception_that_can_not_be_handled_when_validating_it_should_throw()
    {
        var someExceptionNotHandled = new IOException();
        _checkDigitsCalculatorMock
            .Setup(m => m.Compute(It.IsAny<char[]>()))
            .Throws(someExceptionNotHandled)
            .Verifiable();

        // Act
        bool? actual = null;
        Action act = () => actual = _sut.Validate(IbanTestValue);

        // Assert
        act.Should()
            .Throw<IOException>()
            .Which.Should()
            .Be(someExceptionNotHandled);
        actual.Should().BeNull();
        _checkDigitsCalculatorMock.Verify();
    }
}
