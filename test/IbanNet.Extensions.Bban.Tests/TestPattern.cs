using IbanNet.Registry.Patterns;

namespace IbanNet.Extensions.Bban;

internal class TestPattern : Pattern
{
    public TestPattern(IEnumerable<PatternToken> tokens) : base(tokens)
    {
    }
}