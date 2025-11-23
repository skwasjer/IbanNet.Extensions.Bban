namespace IbanNet.Extensions.Bban.CheckDigits;

public sealed class BufferTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Given_that_input_is_empty_when_creating_buffer_it_should_not_throw_and_return_empty_buffer(string? input)
    {
        Action act = () =>
        {
            var buffer = Buffer.Create(input);
            buffer.Length.Should().Be(0);
        };
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(5)]
    public void Given_that_index_is_out_of_range_when_getting_value_it_should_throw(int index)
    {
        Action act = () =>
        {
            var buffer = Buffer.Create("12345");
            _ = buffer[index];
        };

        act.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void When_formatting_it_should_return_expected()
    {
        const string input = "12345";
        var buffer = Buffer.Create(input);
        buffer.ToString().Should().Be(input);
    }

    [Fact]
    public void When_getting_length_it_should_return_expected()
    {
        const string input = "12345";
        Buffer.Create(input).Length.Should().Be(input.Length);
    }
}
