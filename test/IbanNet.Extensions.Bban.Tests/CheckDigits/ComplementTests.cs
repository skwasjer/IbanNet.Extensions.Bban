namespace IbanNet.Extensions.Bban.CheckDigits;

public sealed class ComplementTests
{
    [Theory]
    [MemberData(nameof(GetPadRightTestCases))]
    public void When_padding_right_it_should_return_expected(object complement, int modulo, int remainder, int padding, int expected)
    {
        var sut = (Complement)complement;

        // Act
        int actual = sut.PadRight(padding)(modulo, remainder);

        // Assert
        actual.Should().Be(expected);
    }

    public static TheoryData<object, int, int, int, int> GetPadRightTestCases()
    {
        return new TheoryData<object, int, int, int, int>
        {
            // No padding, so should return unchanged.
            { Complement.Remainder, 10, 5, 0, 5 },

            // 5 * 10 = 50 % 10 = 0
            { Complement.Remainder, 10, 5, 1, 0 },

            // 7 * 10^2 = 700 % 13 = 11
            { Complement.Remainder, 13, 7, 2, 11 },

            // 41 * 10^3 = 41000 % 97 = 66
            { Complement.Remainder, 97, 41, 3, 66 },

            // 41 * 10^3 = 41000 % 97 = 66, then, 97 - 66 = 31
            { Complement.DivisorMinusRemainder, 97, 41, 3, 31 }
        };
    }

    [Fact]
    public void Given_that_length_is_less_than_0_when_padding_right_it_should_throw()
    {
        const int length = -1;
        Complement.Remainder
            .Invoking(complement => complement.PadRight(length))
            .Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithParameterName(nameof(length));
    }

    [Theory]
    [MemberData(nameof(GetComplementTestData))]
    public void When_calculating_the_complement_it_should_return_expected(object complement, int modulo, int remainder, int expected)
    {
        ((Complement)complement)(modulo, remainder).Should().Be(expected);
    }

    public static TheoryData<object, int, int, int> GetComplementTestData()
    {
        return new TheoryData<object, int, int, int>
        {
            // Remainder.
            { Complement.Remainder, 10, 0, 0 },
            { Complement.Remainder, 10, 10, 10 },
            { Complement.Remainder, 10, 8, 8 },
            { Complement.Remainder, 10, 4, 4 },
            { Complement.Remainder, 97, 0, 0 },
            { Complement.Remainder, 97, 97, 97 },
            { Complement.Remainder, 97, 35, 35 },
            { Complement.Remainder, 97, 1, 1 },

            // Divisor minus remainder.
            { Complement.DivisorMinusRemainder, 10, 0, 10 },
            { Complement.DivisorMinusRemainder, 10, 10, 0 },
            { Complement.DivisorMinusRemainder, 10, 8, 2 },
            { Complement.DivisorMinusRemainder, 10, 4, 6 },
            { Complement.DivisorMinusRemainder, 97, 0, 97 },
            { Complement.DivisorMinusRemainder, 97, 97, 0 },
            { Complement.DivisorMinusRemainder, 97, 35, 62 },
            { Complement.DivisorMinusRemainder, 97, 1, 96 },

            // Zero remainder or divisor minus remainder.
            { Complement.ZeroRemainderOrDivisorMinusRemainder, 10, 0, 0 },
            { Complement.ZeroRemainderOrDivisorMinusRemainder, 10, 10, 0 },
            { Complement.ZeroRemainderOrDivisorMinusRemainder, 10, 8, 2 },
            { Complement.ZeroRemainderOrDivisorMinusRemainder, 10, 4, 6 },
            { Complement.ZeroRemainderOrDivisorMinusRemainder, 97, 0, 0 },
            { Complement.ZeroRemainderOrDivisorMinusRemainder, 97, 97, 0 },
            { Complement.ZeroRemainderOrDivisorMinusRemainder, 97, 35, 62 },
            { Complement.ZeroRemainderOrDivisorMinusRemainder, 97, 1, 96 },

            // Zero or one remainder or divisor minus remainder.
            { Complement.ZeroOrOneRemainderOrDivisorMinusRemainder, 10, 0, 0 },
            { Complement.ZeroOrOneRemainderOrDivisorMinusRemainder, 10, 10, 0 },
            { Complement.ZeroOrOneRemainderOrDivisorMinusRemainder, 10, 8, 2 },
            { Complement.ZeroOrOneRemainderOrDivisorMinusRemainder, 10, 4, 6 },
            { Complement.ZeroOrOneRemainderOrDivisorMinusRemainder, 97, 0, 0 },
            { Complement.ZeroOrOneRemainderOrDivisorMinusRemainder, 97, 97, 0 },
            { Complement.ZeroOrOneRemainderOrDivisorMinusRemainder, 97, 35, 62 },
            { Complement.ZeroOrOneRemainderOrDivisorMinusRemainder, 97, 1, 1 },

            // Divisor plus one minus remainder.
            { Complement.DivisorPlusOneMinusRemainder, 10, 0, 11 },
            { Complement.DivisorPlusOneMinusRemainder, 10, 10, 1 },
            { Complement.DivisorPlusOneMinusRemainder, 10, 8, 3 },
            { Complement.DivisorPlusOneMinusRemainder, 10, 4, 7 },
            { Complement.DivisorPlusOneMinusRemainder, 97, 0, 98 },
            { Complement.DivisorPlusOneMinusRemainder, 97, 97, 1 },
            { Complement.DivisorPlusOneMinusRemainder, 97, 35, 63 },
            { Complement.DivisorPlusOneMinusRemainder, 97, 1, 97 }
        };
    }
}
