namespace IbanNet.Extensions.Bban.CheckDigits.Algorithms;

public sealed class Mod9710AlgorithmTests
{
    private readonly Mod9710Algorithm _sut;
    private readonly Complement _complementMock;
    private readonly AsciiConverter _asciiConverterMock;

    public Mod9710AlgorithmTests()
    {
        _complementMock = Substitute.For<Complement>();
        _asciiConverterMock = Substitute.For<AsciiConverter>();

        // Default use divisor - remainder. This is an arbitrary choice, but the test assertions obviously will differ if we change it to something else.
        _complementMock
            .Invoke(Arg.Any<int>(), Arg.Any<int>())
            .Returns(ci => Complement.DivisorMinusRemainder(ci.ArgAt<int>(0), ci.ArgAt<int>(1)));

        // Default mock results use base36 (as the class already does by default). We just want to intercept so we can assert.
        _asciiConverterMock
            .Invoke(Arg.Any<char>())
            .Returns(ci => AsciiConverter.Base36(ci.ArgAt<char>(0)));

        _sut = new Mod9710Algorithm(_complementMock) { AsciiConverter = _asciiConverterMock };
    }

    [Fact]
    public void It_should_have_base36_converter_by_default()
    {
        var sut = new Mod9710Algorithm(_complementMock);

        sut.AsciiConverter.Should().BeSameAs(AsciiConverter.Base36);
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void It_should_return_expected(string input, int expectedResult, int expectedRemainder)
    {
        int actual = _sut.Compute(input);

        // Assert
        actual.Should().Be(expectedResult);
        _asciiConverterMock.ReceivedCalls()
            .Select(ci => (char)ci.GetArguments()[0]!)
            .Should()
            .BeEquivalentTo(input, opts => opts.WithStrictOrdering());
        _complementMock.Received(1).Invoke(97, expectedRemainder);
    }

    public static TheoryData<string, int, int> TestCases => new()
    {
        { "", 97, 0 },
        { "0", 97, 0 },
        { "A", 87, 10 },
        { "ABCDEFG", 70, 27 },
        { "1234567890", 95, 2 },
        { "209876541320987654130", 46, 51 },
        { "1234567890ZYX", 78, 19 },
        { "65242074034895615069018425766175325148134413755480937177823183347306537990349539826366434011349528759099450602366561132678465015", 81, 16 },
        { "ABNA0417164300NL91", 96, 1 },
        { "MALT011000012345MTLCAST001SMT84", 96, 1 }
    };

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

            int actual = sut.Compute(input);

            // Assert
            actual.Should().Be(expectedResult);
        }
    }
}
