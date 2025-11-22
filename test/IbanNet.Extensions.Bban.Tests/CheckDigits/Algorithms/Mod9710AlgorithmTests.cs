namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public sealed class Mod9710AlgorithmTests
{
    private readonly Mod9710Algorithm _sut;
    private readonly Complement _complementMock;

    public Mod9710AlgorithmTests()
    {
        _complementMock = Substitute.For<Complement>();

        // Default use divisor - remainder. This is an arbitrary choice, but the test assertions obviously will differ if we change it to something else.
        _complementMock
            .Invoke(Arg.Any<int>(), Arg.Any<int>())
            .Returns(ci => Complement.DivisorMinusRemainder(ci.ArgAt<int>(0), ci.ArgAt<int>(1)));

        _sut = new Mod9710Algorithm(_complementMock);
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void It_should_return_expected(string input, int expectedResult, int expectedRemainder)
    {
        _sut.Compute(input).Should().Be(expectedResult);
        _complementMock.Received(1).Invoke(97, expectedRemainder);
    }

    public static TheoryData<string, int, int> TestCases => new()
    {
        { "", 97, 0 },
        { "0", 97, 0 },
        { "A", 87, 10 },
        { "Z", 62, 35 },
        { "ABCDEFG", 70, 27 },
        { "1234567890", 95, 2 },
        { "209876541320987654130", 46, 51 },
        { "1234567890ZYX", 78, 19 },
        { "65242074034895615069018425766175325148134413755480937177823183347306537990349539826366434011349528759099450602366561132678465015", 81, 16 },
        { "ABNA0417164300NL91", 96, 1 },
        { "MALT011000012345MTLCAST001SMT84", 96, 1 },
        { "abna0417164300nl91", 96, 1 }, // Lower case.
        { "MAlt011000012345MTlcaST001SmT84", 96, 1 } // Mixed case.
    };

    [Theory]
    [InlineData("12A:b56", ':', 3)]
    [InlineData("12AB56é", 'é', 6)]
    public void Given_that_input_contains_a_non_alphaNumeric_character_when_computing_it_should_throw(string value, char invalidChar, int errorPosition)
    {
        _sut.Invoking(s => s.Compute(value))
            .Should()
            .Throw<InvalidTokenException>()
            .WithMessage($"Expected alphanumeric character at position {errorPosition}, but found '{invalidChar}'.");
    }

    /// <summary>
    /// Runs the same test cases as in the mocked tests, but this is to ensure our mocks/setups are not hiding any issues.
    /// </summary>
    [Trait("Category", "Integration")]
    public sealed class IntegrationTests
    {
        [Theory]
        [MemberData(nameof(TestCases), MemberType = typeof(Mod9710AlgorithmTests))]
        public void It_should_return_expected(string input, int expectedResult, int _)
        {
            var sut = new Mod9710Algorithm(Complement.DivisorMinusRemainder);
            sut.Compute(input).Should().Be(expectedResult);
        }
    }
}
