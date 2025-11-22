using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MemoryDiagnoser]
public sealed class FinlandBenchmark : ValidatorBenchmark
{
    private readonly Finland _validator = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "10093000123458";
    }

    [Benchmark]
    public void Validate()
    {
        Assert.True(_validator.Validate(_input));
    }
}
