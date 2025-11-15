using System;
using System.Collections.Generic;
using IbanNet.CheckDigits.Calculators;

namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public class NibAlgorithmTests
{
    private readonly NibAlgorithm _sut;

    public NibAlgorithmTests()
    {
        _sut = new NibAlgorithm();
    }

    [Theory]
    [InlineData("12345123451234567A1", 25)]
    [InlineData("12345123451234567A2", 22)]
    [InlineData("20041010050500013M0", 29)]
    [InlineData("3000600001123456789", 64)]
    public void Given_account_number_when_computing_check_digit_should_match_expected(string accountNumber, int expectedCheckDigits)
    {
        // Act
        int actual = _sut.Compute(accountNumber.ToCharArray());

        // Assert
        actual.Should().Be(expectedCheckDigits);
    }

    [Theory]
    [InlineData("02345123451234567A1", 25)]
    [InlineData("02345123451234567A2", 22)]
    [InlineData("00041010050500013M0", 29)]
    [InlineData("1000600001123456789", 64)]
    public void Given_invalid_account_number_when_computing_check_digit_should_not_match_expected(string accountNumber, int assumedCheckDigits)
    {
        // Act
        int actual = _sut.Compute(accountNumber.ToCharArray());

        // Assert
        actual.Should().NotBe(assumedCheckDigits);
    }

    [Theory]
    [InlineData("Short18CharsLong..")]
    [InlineData("TooShort")]
    public void Given_account_number_contains_insufficient_chars_when_computing_should_throw(string value)
    {
        Action act = () => _sut.Compute(value.ToCharArray());

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage($"The input '{value}' can not be validated using NIB.*")
            .Which.ParamName.Should()
            .Be(nameof(value));
    }

    [Theory]
    [InlineData("02345123451234567A:")]
    public void Given_a_non_alphanumeric_character_when_computing_should_throw(string value)
    {
        Action act = () => _sut.Compute(value.ToCharArray());

        // Assert
        act.Should()
            .Throw<InvalidTokenException>()
            .WithMessage($"Expected alphanumeric characters.");
    }

    /// <summary>
    /// Asserts correct mapping of letters.
    /// </summary>
    [Theory]
    [MemberData(nameof(SingleDigitTestCases))]
    public void Given_single_digit_account_number_when_validating_it_should_return_correct_check_digit(string singleDigitAccountNumber, int expectedCheckDigits)
    {
        // Act
        int actual = _sut.Compute(singleDigitAccountNumber.ToCharArray());

        // Assert
        actual.Should().Be(expectedCheckDigits);
    }

    public static IEnumerable<object[]> SingleDigitTestCases()
    {
        const char charCodeA = 'A';
        for (int i = 0; i < 26; i++)
        {
            char digit = ((char)(charCodeA + i));
            string accountNumber = digit.ToString().PadLeft(19, '0');
            int expectedCheckDigits = 98 - (i % 9 + 1) * 3;
            if (digit >= 'S')   // 3rd row
            {
                expectedCheckDigits -= 3;
            }
            yield return [accountNumber, expectedCheckDigits];
        }
    }
}