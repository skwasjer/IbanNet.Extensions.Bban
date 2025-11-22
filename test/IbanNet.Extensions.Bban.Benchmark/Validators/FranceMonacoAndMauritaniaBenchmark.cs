using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MemoryDiagnoser]
public sealed class FranceMonacoAndMauritaniaBenchmark : ValidatorBenchmark
{
    private readonly FranceMonacoAndMauritania _validator = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "30006000011234567890189";
    }

    [Benchmark]
    public void Validate()
    {
        Assert.True(_validator.Validate(_input));
    }
}
