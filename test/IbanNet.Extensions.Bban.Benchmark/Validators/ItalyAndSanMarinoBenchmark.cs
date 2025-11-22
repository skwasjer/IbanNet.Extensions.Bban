using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MemoryDiagnoser]
public sealed class ItalyAndSanMarinoBenchmark : ValidatorBenchmark
{
    private readonly ItalyAndSanMarino _validator = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "U9382566253RRP8KQG4ALJZ";
    }

    [Benchmark]
    public void Validate()
    {
        Assert.True(_validator.Validate(_input));
    }
}
