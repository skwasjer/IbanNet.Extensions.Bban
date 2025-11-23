namespace IbanNet.Extensions.Bban.CheckDigits;

public sealed class BufferExtensionTests
{
    public sealed class GetDigitValueTests
    {
        [Theory]
        [InlineData(0, 9)]
        [InlineData(1, 8)]
        [InlineData(2, 7)]
        [InlineData(3, 6)]
        [InlineData(4, 5)]
        [InlineData(5, 4)]
        [InlineData(6, 3)]
        [InlineData(7, 2)]
        [InlineData(8, 1)]
        [InlineData(9, 0)]
        public void It_should_return_expected_value(int index, int expected)
        {
            var buffer = Buffer.Create("9876543210");
            buffer.GetDigitValue(index).Should().Be(expected);
        }

        [Theory]
        [InlineData("0:A", ':', 1)]
        [InlineData("0:A", 'A', 2)]
        [InlineData("3zAé", 'z', 1)]
        [InlineData("3zAé", 'é', 3)]
        public void Given_that_char_is_not_valid_when_getting_value_it_should_throw(string bufferValue, char invalidChar, int position)
        {
            Action act = () =>
            {
                var buffer = Buffer.Create(bufferValue);
                _ = buffer.GetDigitValue(position);
            };

            act.Should()
                .Throw<InvalidTokenException>()
                .WithMessage($"Expected numeric character at position {position}, but found '{invalidChar}'.");
        }
    }

    public sealed class GetBase36ValueTests
    {
        [Theory]
        [InlineData(0, 9)]
        [InlineData(1, 8)]
        [InlineData(2, 7)]
        [InlineData(3, 6)]
        [InlineData(4, 5)]
        [InlineData(5, 4)]
        [InlineData(6, 3)]
        [InlineData(7, 2)]
        [InlineData(8, 1)]
        [InlineData(9, 0)]
        [InlineData(10, 35)] // 'Z'
        [InlineData(11, 34)] // 'Y'
        [InlineData(12, 33)] // 'X'
        [InlineData(13, 32)] // 'W'
        [InlineData(14, 31)] // 'V'
        [InlineData(15, 30)] // 'U'
        [InlineData(16, 29)] // 'T'
        [InlineData(17, 28)] // 'S'
        [InlineData(18, 27)] // 'R'
        [InlineData(19, 26)] // 'Q'
        [InlineData(20, 25)] // 'P'
        [InlineData(21, 24)] // 'O'
        [InlineData(22, 23)] // 'N'
        [InlineData(23, 22)] // 'M'
        [InlineData(24, 21)] // 'L'
        [InlineData(25, 20)] // 'K'
        [InlineData(26, 19)] // 'J'
        [InlineData(27, 18)] // 'I'
        [InlineData(28, 17)] // 'H'
        [InlineData(29, 16)] // 'G'
        [InlineData(30, 15)] // 'F'
        [InlineData(31, 14)] // 'E'
        [InlineData(32, 13)] // 'D'
        [InlineData(33, 12)] // 'C'
        [InlineData(34, 11)] // 'B'
        [InlineData(35, 10)] // 'A'
        [InlineData(36, 35)] // 'z'
        [InlineData(37, 34)] // 'y'
        [InlineData(38, 33)] // 'x'
        [InlineData(39, 32)] // 'w'
        [InlineData(40, 31)] // 'v'
        [InlineData(41, 30)] // 'u'
        [InlineData(42, 29)] // 't'
        [InlineData(43, 28)] // 's'
        [InlineData(44, 27)] // 'r'
        [InlineData(45, 26)] // 'q'
        [InlineData(46, 25)] // 'p'
        [InlineData(47, 24)] // 'o'
        [InlineData(48, 23)] // 'n'
        [InlineData(49, 22)] // 'm'
        [InlineData(50, 21)] // 'l'
        [InlineData(51, 20)] // 'k'
        [InlineData(52, 19)] // 'j'
        [InlineData(53, 18)] // 'i'
        [InlineData(54, 17)] // 'h'
        [InlineData(55, 16)] // 'g'
        [InlineData(56, 15)] // 'f'
        [InlineData(57, 14)] // 'e'
        [InlineData(58, 13)] // 'd'
        [InlineData(59, 12)] // 'c'
        [InlineData(60, 11)] // 'b'
        [InlineData(61, 10)] // 'a'
        public void It_should_return_expected_value(int index, int expected)
        {
            var buffer = Buffer.Create("9876543210ZYXWVUTSRQPONMLKJIHGFEDCBAzyxwvutsrqponmlkjihgfedcba");
            buffer.GetBase36Value(index).Should().Be(expected);
        }

        [Theory]
        [InlineData("0:A", ':', 1)]
        [InlineData("3zAé", 'é', 3)]
        public void Given_that_char_is_not_valid_when_getting_value_it_should_throw(string bufferValue, char invalidChar, int position)
        {
            Action act = () =>
            {
                var buffer = Buffer.Create(bufferValue);
                _ = buffer.GetBase36Value(position);
            };

            act.Should()
                .Throw<InvalidTokenException>()
                .WithMessage($"Expected alphanumeric character at position {position}, but found '{invalidChar}'.");
        }
    }

    public sealed class GetOrdinalValueTests
    {
        [Theory]
        [InlineData(0, 9)]
        [InlineData(1, 8)]
        [InlineData(2, 7)]
        [InlineData(3, 6)]
        [InlineData(4, 5)]
        [InlineData(5, 4)]
        [InlineData(6, 3)]
        [InlineData(7, 2)]
        [InlineData(8, 1)]
        [InlineData(9, 0)]
        [InlineData(10, 25)] // 'Z'
        [InlineData(11, 24)] // 'Y'
        [InlineData(12, 23)] // 'X'
        [InlineData(13, 22)] // 'W'
        [InlineData(14, 21)] // 'V'
        [InlineData(15, 20)] // 'U'
        [InlineData(16, 19)] // 'T'
        [InlineData(17, 18)] // 'S'
        [InlineData(18, 17)] // 'R'
        [InlineData(19, 16)] // 'Q'
        [InlineData(20, 15)] // 'P'
        [InlineData(21, 14)] // 'O'
        [InlineData(22, 13)] // 'N'
        [InlineData(23, 12)] // 'M'
        [InlineData(24, 11)] // 'L'
        [InlineData(25, 10)] // 'K'
        [InlineData(26, 9)] // 'J'
        [InlineData(27, 8)] // 'I'
        [InlineData(28, 7)] // 'H'
        [InlineData(29, 6)] // 'G'
        [InlineData(30, 5)] // 'F'
        [InlineData(31, 4)] // 'E'
        [InlineData(32, 3)] // 'D'
        [InlineData(33, 2)] // 'C'
        [InlineData(34, 1)] // 'B'
        [InlineData(35, 0)] // 'A'
        [InlineData(36, 25)] // 'z'
        [InlineData(37, 24)] // 'y'
        [InlineData(38, 23)] // 'x'
        [InlineData(39, 22)] // 'w'
        [InlineData(40, 21)] // 'v'
        [InlineData(41, 20)] // 'u'
        [InlineData(42, 19)] // 't'
        [InlineData(43, 18)] // 's'
        [InlineData(44, 17)] // 'r'
        [InlineData(45, 16)] // 'q'
        [InlineData(46, 15)] // 'p'
        [InlineData(47, 14)] // 'o'
        [InlineData(48, 13)] // 'n'
        [InlineData(49, 12)] // 'm'
        [InlineData(50, 11)] // 'l'
        [InlineData(51, 10)] // 'k'
        [InlineData(52, 9)] // 'j'
        [InlineData(53, 8)] // 'i'
        [InlineData(54, 7)] // 'h'
        [InlineData(55, 6)] // 'g'
        [InlineData(56, 5)] // 'f'
        [InlineData(57, 4)] // 'e'
        [InlineData(58, 3)] // 'd'
        [InlineData(59, 2)] // 'c'
        [InlineData(60, 1)] // 'b'
        [InlineData(61, 0)] // 'a'
        public void It_should_return_expected_value(int index, int expected)
        {
            var buffer = Buffer.Create("9876543210ZYXWVUTSRQPONMLKJIHGFEDCBAzyxwvutsrqponmlkjihgfedcba");
            buffer.GetOrdinalValue(index).Should().Be(expected);
        }

        [Theory]
        [InlineData("0:A", ':', 1)]
        [InlineData("3zAé", 'é', 3)]
        public void Given_that_char_is_not_valid_when_getting_value_it_should_throw(string bufferValue, char invalidChar, int position)
        {
            Action act = () =>
            {
                var buffer = Buffer.Create(bufferValue);
                _ = buffer.GetOrdinalValue(position);
            };
            act.Should()
                .Throw<InvalidTokenException>()
                .WithMessage($"Expected alphanumeric character at position {position}, but found '{invalidChar}'.");
        }
    }

    public sealed class GetAlphaNumericBase10ValueTests
    {
        [Theory]
        [InlineData(0, 9)]
        [InlineData(1, 8)]
        [InlineData(2, 7)]
        [InlineData(3, 6)]
        [InlineData(4, 5)]
        [InlineData(5, 4)]
        [InlineData(6, 3)]
        [InlineData(7, 2)]
        [InlineData(8, 1)]
        [InlineData(9, 0)]
        [InlineData(10, 9)] // 'Z'
        [InlineData(11, 8)] // 'Y'
        [InlineData(12, 7)] // 'X'
        [InlineData(13, 6)] // 'W'
        [InlineData(14, 5)] // 'V'
        [InlineData(15, 4)] // 'U'
        [InlineData(16, 3)] // 'T'
        [InlineData(17, 2)] // 'S'
        [InlineData(18, 9)] // 'R'
        [InlineData(19, 8)] // 'Q'
        [InlineData(20, 7)] // 'P'
        [InlineData(21, 6)] // 'O'
        [InlineData(22, 5)] // 'N'
        [InlineData(23, 4)] // 'M'
        [InlineData(24, 3)] // 'L'
        [InlineData(25, 2)] // 'K'
        [InlineData(26, 1)] // 'J'
        [InlineData(27, 9)] // 'I'
        [InlineData(28, 8)] // 'H'
        [InlineData(29, 7)] // 'G'
        [InlineData(30, 6)] // 'F'
        [InlineData(31, 5)] // 'E'
        [InlineData(32, 4)] // 'D'
        [InlineData(33, 3)] // 'C'
        [InlineData(34, 2)] // 'B'
        [InlineData(35, 1)] // 'A'
        [InlineData(36, 9)] // 'z'
        [InlineData(37, 8)] // 'y'
        [InlineData(38, 7)] // 'x'
        [InlineData(39, 6)] // 'w'
        [InlineData(40, 5)] // 'v'
        [InlineData(41, 4)] // 'u'
        [InlineData(42, 3)] // 't'
        [InlineData(43, 2)] // 's'
        [InlineData(44, 9)] // 'r'
        [InlineData(45, 8)] // 'q'
        [InlineData(46, 7)] // 'p'
        [InlineData(47, 6)] // 'o'
        [InlineData(48, 5)] // 'n'
        [InlineData(49, 4)] // 'm'
        [InlineData(50, 3)] // 'l'
        [InlineData(51, 2)] // 'k'
        [InlineData(52, 1)] // 'j'
        [InlineData(53, 9)] // 'i'
        [InlineData(54, 8)] // 'h'
        [InlineData(55, 7)] // 'g'
        [InlineData(56, 6)] // 'f'
        [InlineData(57, 5)] // 'e'
        [InlineData(58, 4)] // 'd'
        [InlineData(59, 3)] // 'c'
        [InlineData(60, 2)] // 'b'
        [InlineData(61, 1)] // 'a'
        public void It_should_return_expected_value(int index, int expected)
        {
            var buffer = Buffer.Create("9876543210ZYXWVUTSRQPONMLKJIHGFEDCBAzyxwvutsrqponmlkjihgfedcba");
            buffer.GetAlphaNumericBase10Value(index).Should().Be(expected);
        }

        [Theory]
        [InlineData("0:A", ':', 1)]
        [InlineData("3zAé", 'é', 3)]
        public void Given_that_char_is_not_valid_when_getting_value_it_should_throw(string bufferValue, char invalidChar, int position)
        {
            Action act = () =>
            {
                var buffer = Buffer.Create(bufferValue);
                _ = buffer.GetAlphaNumericBase10Value(position);
            };
            act.Should()
                .Throw<InvalidTokenException>()
                .WithMessage($"Expected alphanumeric character at position {position}, but found '{invalidChar}'.");
        }
    }
}
