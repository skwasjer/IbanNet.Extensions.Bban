namespace IbanNet.Extensions.Bban.CheckDigits;

public static class AsciiConverterTests
{
    public sealed class DigitsTests
    {
        [Theory]
        [InlineData('0', 0)]
        [InlineData('5', 5)]
        [InlineData('9', 9)]
        public void Given_that_char_is_an_ascii_digit_it_should_convert_to_expected_value(char ch, int expectedValue)
        {
            AsciiConverter.Digits(ch).Should().Be(expectedValue);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('z')]
        [InlineData('⒈')]
        [InlineData('¾')]
        public void Given_that_char_is_not_an_ascii_digit_when_converting_it_should_throw(char ch)
        {
            // Act
            Func<int> act = () => AsciiConverter.Digits(ch);

            // Assert
            act.Should()
                .Throw<InvalidTokenException>()
                .WithMessage("*is not a valid digit character*");
        }
    }

    public sealed class Base36Tests
    {
        [Theory]
        [InlineData('0', 0)]
        [InlineData('5', 5)]
        [InlineData('9', 9)]
        [InlineData('a', 10)]
        [InlineData('A', 10)]
        [InlineData('k', 20)]
        [InlineData('S', 28)]
        [InlineData('z', 35)]
        [InlineData('Z', 35)]
        public void Given_that_char_is_an_alphaNumeric_character_it_should_convert_to_expected_value(char ch, int expectedValue)
        {
            AsciiConverter.Base36(ch).Should().Be(expectedValue);
        }

        [Theory]
        [InlineData('⒈')]
        [InlineData('¾')]
        [InlineData('ë')]
        [InlineData('å')]
        public void Given_that_char_is_not_an_alphaNumeric_character_when_converting_it_should_throw(char ch)
        {
            // Act
            Func<int> act = () => AsciiConverter.Base36(ch);

            // Assert
            act.Should()
                .Throw<InvalidTokenException>()
                .WithMessage("*is not a valid alphanumeric character*");
        }
    }
}
