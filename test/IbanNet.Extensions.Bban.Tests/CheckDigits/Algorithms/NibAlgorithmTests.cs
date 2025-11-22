namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public sealed class NibAlgorithmTests
{
    private readonly NibAlgorithm _sut = new();

    [Theory]
    [InlineData("12345123451234567A1", 25)]
    [InlineData("12345123451234567a2", 22)]
    [InlineData("20041010050500013M0", 29)]
    [InlineData("3000600001123456789", 64)]
    [InlineData("9999999999999999999", 50)]
    public void It_should_return_expected(string input, int expectedResult)
    {
        _sut.Compute(input).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("123:5123451234567A1", ':', 3)]
    [InlineData("123451234512345é7A1", 'é', 15)]
    public void Given_that_input_contains_a_non_alphaNumeric_character_when_computing_it_should_throw(string value, char invalidChar, int errorPosition)
    {
        _sut.Invoking(s => s.Compute(value))
            .Should()
            .Throw<InvalidTokenException>()
            .WithMessage($"Expected alphanumeric character at position {errorPosition}, but found '{invalidChar}'.");
    }

    [Theory]
    [InlineData("Short18CharsLong..")]
    [InlineData("TooShort")]
    [InlineData("TooLongForNibToValidate")]
    public void Given_that_input_contains_the_wrong_number_of_chars_when_computing_it_should_throw(string buffer)
    {
        _sut.Invoking(s => s.Compute(buffer))
            .Should()
            .Throw<ArgumentException>()
            .WithMessage($"The input '{buffer}' can not be validated using NIB.*")
            .WithParameterName(nameof(buffer));
    }

    /// <summary>
    /// Asserts correct mapping of letters.
    /// </summary>
    [Theory]
    [MemberData(nameof(SingleDigitTestCases))]
    public void Given_single_digit_account_number_when_validating_it_should_return_correct_check_digit(string singleDigitAccountNumber, int expectedCheckDigits)
    {
        // Act
        int actual = _sut.Compute(singleDigitAccountNumber);

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
