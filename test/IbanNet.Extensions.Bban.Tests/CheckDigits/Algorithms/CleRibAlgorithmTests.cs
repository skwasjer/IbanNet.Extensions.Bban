namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public sealed class CleRibAlgorithmTests
{
    private readonly CleRibAlgorithm _sut = new();

    [Theory]
    [InlineData("12345123451234567891A", 16)]
    [InlineData("12345123451234567891B", 13)]
    [InlineData("20041010050500013M026", 06)]
    [InlineData("300060000112345678901", 89)]
    public void It_should_return_expected(string input, int expectedResult)
    {
        _sut.Compute(input).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("123:5123451234567891A", ':', 3)]
    [InlineData("123451234512345é7891A", 'é', 15)]
    public void Given_that_input_contains_a_non_alphaNumeric_character_when_computing_it_should_throw(string value, char invalidChar, int errorPosition)
    {
        _sut.Invoking(s => s.Compute(value))
            .Should()
            .Throw<InvalidTokenException>()
            .WithMessage($"Expected alphanumeric character at position {errorPosition}, but found '{invalidChar}'.");
    }

    [Theory]
    [InlineData("ShortAnd20CharsLong.")]
    [InlineData("TooShort")]
    [InlineData("TooLongForCleRibToValidate")]
    public void Given_that_input_contains_the_wrong_number_of_chars_when_computing_it_should_throw(string buffer)
    {
        _sut.Invoking(s => s.Compute(buffer))
            .Should()
            .Throw<ArgumentException>()
            .WithMessage($"The input '{buffer}' can not be validated using clé RIB.*")
            .WithParameterName(nameof(buffer));
    }

    /// <summary>
    /// Asserts correct mapping of digits/letters.
    /// </summary>
    [Theory]
    [MemberData(nameof(SingleCharTestCases))]
    public void Given_that_input_is_single_char_account_number_when_computing_it_should_return_expected(string singleCharAccountNumber, int expectedResult)
    {
        _sut.Compute(singleCharAccountNumber).Should().Be(expectedResult);
    }

    /// <summary>
    /// Returns all possible permutations for the last char.
    /// </summary>
    public static TheoryData<string, int> SingleCharTestCases
    {
        get => new()
        {
            { "000000000000000000000", 97 },
            { "000000000000000000001", 94 },
            { "000000000000000000002", 91 },
            { "000000000000000000003", 88 },
            { "000000000000000000004", 85 },
            { "000000000000000000005", 82 },
            { "000000000000000000006", 79 },
            { "000000000000000000007", 76 },
            { "000000000000000000008", 73 },
            { "000000000000000000009", 70 },
            { "00000000000000000000A", 94 },
            { "00000000000000000000B", 91 },
            { "00000000000000000000C", 88 },
            { "00000000000000000000D", 85 },
            { "00000000000000000000E", 82 },
            { "00000000000000000000F", 79 },
            { "00000000000000000000G", 76 },
            { "00000000000000000000H", 73 },
            { "00000000000000000000I", 70 },
            { "00000000000000000000J", 94 },
            { "00000000000000000000K", 91 },
            { "00000000000000000000L", 88 },
            { "00000000000000000000M", 85 },
            { "00000000000000000000N", 82 },
            { "00000000000000000000O", 79 },
            { "00000000000000000000P", 76 },
            { "00000000000000000000Q", 73 },
            { "00000000000000000000R", 70 },
            { "00000000000000000000S", 91 },
            { "00000000000000000000T", 88 },
            { "00000000000000000000U", 85 },
            { "00000000000000000000V", 82 },
            { "00000000000000000000W", 79 },
            { "00000000000000000000X", 76 },
            { "00000000000000000000Y", 73 },
            { "00000000000000000000Z", 70 }
        };
    }
}
