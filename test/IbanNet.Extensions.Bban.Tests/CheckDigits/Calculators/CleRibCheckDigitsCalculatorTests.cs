using System;
using System.Collections.Generic;

namespace IbanNet.Extensions.Bban.CheckDigits.Calculators;

public class CleRibCheckDigitsCalculatorTests
{
    private readonly CleRibCheckDigitsCalculator _sut;

    public CleRibCheckDigitsCalculatorTests()
    {
        _sut = new CleRibCheckDigitsCalculator();
    }

    [Theory]
    [InlineData("12345123451234567891A", 16)]
    [InlineData("12345123451234567891B", 13)]
    [InlineData("20041010050500013M026", 06)]
    [InlineData("300060000112345678901", 89)]
    public void Given_account_number_when_computing_check_digit_should_match_expected(string accountNumber, int expectedCheckDigits)
    {
        // Act
        int actual = _sut.Compute(accountNumber.ToCharArray());

        // Assert
        actual.Should().Be(expectedCheckDigits);
    }

    [Theory]
    [InlineData("02345123451234567891A", 16)]
    [InlineData("02345123451234567891B", 13)]
    [InlineData("10041010050500013M026", 06)]
    [InlineData("200060000112345678901", 89)]
    public void Given_invalid_account_number_when_computing_check_digit_should_not_match_expected(string accountNumber, int assumedCheckDigits)
    {
        // Act
        int actual = _sut.Compute(accountNumber.ToCharArray());

        // Assert
        actual.Should().NotBe(assumedCheckDigits);
    }

    [Theory]
    [InlineData("ShortAnd20CharsLong.")]
    [InlineData("TooShort")]
    public void Given_account_number_contains_insufficient_chars_when_computing_should_throw(string value)
    {
        Action act = () => _sut.Compute(value.ToCharArray());

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage($"The input '{value}' can not be validated using clé RIB.*")
            .Which.ParamName.Should()
            .Be(nameof(value));
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
            string accountNumber = digit.ToString().PadLeft(21, '0');
            int expectedCheckDigits = 97 - (i % 9 + 1) * 3;
            if (digit >= 'S')   // 3rd row
            {
                expectedCheckDigits -= 3;
            }
            yield return [accountNumber, expectedCheckDigits];
        }
    }
}