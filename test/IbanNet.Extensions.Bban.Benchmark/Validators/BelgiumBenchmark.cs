using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MemoryDiagnoser]
public sealed class BelgiumBenchmark : ValidatorBenchmark
{
    private readonly Belgium _validator = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "539007547034";
    }

    [Benchmark]
    public void Validate()
    {
        Assert.True(_validator.Validate(_input));
    }
}
