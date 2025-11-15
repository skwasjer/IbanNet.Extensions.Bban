using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using IbanNet.CheckDigits.Calculators;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

public class NationalCheckDigitsValidatorTests
{
    private const string IbanTestValue = "some_fake_value";
    private const string CheckStringTestValue = "fake_value";

    private readonly ICheckDigitsCalculator _checkDigitsCalculatorMock;
    private readonly CheckString _getCheckStringFuncMock;
    private readonly CheckDigits _getCheckDigitsFuncMock;
    private readonly NationalCheckDigitsValidator _sut;

    public NationalCheckDigitsValidatorTests()
    {
        _checkDigitsCalculatorMock = Substitute.For<ICheckDigitsCalculator>();

        _getCheckStringFuncMock = Substitute.For<CheckString>();
        _getCheckDigitsFuncMock = Substitute.For<CheckDigits>();

        _sut = Substitute.ForPartsOf<NationalCheckDigitsValidator>(_checkDigitsCalculatorMock, _getCheckStringFuncMock, _getCheckDigitsFuncMock);

        _getCheckStringFuncMock
            .Invoke(Arg.Any<string>())
            .Returns(CheckStringTestValue);
    }

    [Fact]
    public void It_should_call_calculator_with_checkstring_and_validate()
    {
        _getCheckDigitsFuncMock
            .Invoke(Arg.Any<string>())
            .Returns(123);

        _checkDigitsCalculatorMock
            .Compute(Arg.Is<char[]>(ch => ch.SequenceEqual(CheckStringTestValue)))
            .Returns(123);

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
        _checkDigitsCalculatorMock
            .Received(1)
            .Compute(Arg.Is<char[]>(ch => ch.SequenceEqual(CheckStringTestValue)));
    }

    public static IEnumerable<object[]> ShouldNotThrowExceptionCases()
    {
        yield return [new InvalidTokenException("error")];
        yield return [new ArgumentException("error")];
    }

    [Theory]
    [MemberData(nameof(ShouldNotThrowExceptionCases))]
    public void Given_that_calculator_throws_exception_that_can_be_handled_when_validating_it_should_not_throw(Exception ex)
    {
        _checkDigitsCalculatorMock
            .Compute(Arg.Any<char[]>())
            .Throws(ex);

        // Act
        bool? actual = null;
        Action act = () => actual = _sut.Validate(IbanTestValue);

        // Assert
        act.Should().NotThrow();
        actual.Should().BeFalse();
        _checkDigitsCalculatorMock
            .Received(1)
            .Compute(Arg.Any<char[]>());
    }

    [Fact]
    public void Given_that_calculator_throws_exception_that_can_not_be_handled_when_validating_it_should_throw()
    {
        var someExceptionNotHandled = new IOException();
        _checkDigitsCalculatorMock
            .Compute(Arg.Any<char[]>())
            .Throws(someExceptionNotHandled);

        // Act
        bool? actual = null;
        Action act = () => actual = _sut.Validate(IbanTestValue);

        // Assert
        act.Should()
            .Throw<IOException>()
            .Which.Should()
            .Be(someExceptionNotHandled);
        actual.Should().BeNull();
        _checkDigitsCalculatorMock
            .Received(1)
            .Compute(Arg.Any<char[]>());
    }
}
