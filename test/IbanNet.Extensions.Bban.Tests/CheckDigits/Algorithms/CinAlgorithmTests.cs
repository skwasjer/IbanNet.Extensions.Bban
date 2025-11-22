namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public sealed class CinAlgorithmTests
{
    private readonly CinAlgorithm _sut = new();

    [Theory]
    [InlineData("0114962654315W0AV67Q9J", 2)]
    [InlineData("0900245288OKALSKMZQPVZ", 8)]
    [InlineData("9382566253RRP8KQG4ALJZ", 20)]
    public void It_should_return_expected(string input, int expectedResult)
    {
        _sut.Compute(input).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("011:962654315W0AV67Q9J", ':', 3)]
    [InlineData("0114962654315W0éV67Q9J", 'é', 15)]
    public void Given_that_input_contains_a_non_alphaNumeric_character_when_computing_it_should_throw(string value, char invalidChar, int errorPosition)
    {
        _sut.Invoking(s => s.Compute(value))
            .Should()
            .Throw<InvalidTokenException>()
            .WithMessage($"Expected alphanumeric character at position {errorPosition}, but found '{invalidChar}'.");
    }

    /// <summary>
    /// Asserts correct mapping of digits/letters.
    /// </summary>
    [Theory]
    [MemberData(nameof(WeightTestCases))]
    public void Given_that_input_contains_simple_account_number_when_computing_it_should_return_expected(string singleCharAccountNumber, int expectedResult)
    {
        _sut.Compute(singleCharAccountNumber).Should().Be(expectedResult);
    }

    /// <summary>
    /// Returns all possible permutations that map to the even/odd weights.
    /// </summary>
    public static TheoryData<string, int> WeightTestCases
    {
        get => new()
        {
            // It should yield exactly the odd (1-based) index weights.
            { "0", 1 },
            { "1", 0 },
            { "2", 5 },
            { "3", 7 },
            { "4", 9 },
            { "5", 13 },
            { "6", 15 },
            { "7", 17 },
            { "8", 19 },
            { "9", 21 },
            { "A", 1 },
            { "B", 0 },
            { "C", 5 },
            { "D", 7 },
            { "E", 9 },
            { "F", 13 },
            { "G", 15 },
            { "H", 17 },
            { "I", 19 },
            { "J", 21 },
            { "K", 2 },
            { "L", 4 },
            { "M", 18 },
            { "N", 20 },
            { "O", 11 },
            { "P", 3 },
            { "Q", 6 },
            { "R", 8 },
            { "S", 12 },
            { "T", 14 },
            { "U", 16 },
            { "V", 10 },
            { "W", 22 },
            { "X", 25 },
            { "Y", 24 },
            { "Z", 23 },

            // It should yield exactly the even (1-based) index weights.
            { "10", 0 },
            { "11", 1 },
            { "12", 2 },
            { "13", 3 },
            { "14", 4 },
            { "15", 5 },
            { "16", 6 },
            { "17", 7 },
            { "18", 8 },
            { "19", 9 },
            { "1A", 0 },
            { "1B", 1 },
            { "1C", 2 },
            { "1D", 3 },
            { "1E", 4 },
            { "1F", 5 },
            { "1G", 6 },
            { "1H", 7 },
            { "1I", 8 },
            { "1J", 9 },
            { "1K", 10 },
            { "1L", 11 },
            { "1M", 12 },
            { "1N", 13 },
            { "1O", 14 },
            { "1P", 15 },
            { "1Q", 16 },
            { "1R", 17 },
            { "1S", 18 },
            { "1T", 19 },
            { "1U", 20 },
            { "1V", 21 },
            { "1W", 22 },
            { "1X", 23 },
            { "1Y", 24 },
            { "1Z", 25 }
        };
    }
}
