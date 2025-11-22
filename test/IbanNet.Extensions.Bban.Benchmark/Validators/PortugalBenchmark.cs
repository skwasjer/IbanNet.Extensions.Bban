using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MemoryDiagnoser]
public class PortugalBenchmark : ValidatorBenchmark
{
    private readonly Portugal _validator = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "123443211234567890172";
    }

    [Benchmark]
    public void Validate()
    {
        Assert.True(_validator.Validate(_input));
    }
}
