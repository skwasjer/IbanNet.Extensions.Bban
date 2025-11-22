using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MemoryDiagnoser]
public class PolandBenchmark : ValidatorBenchmark
{
    private readonly PolishNationalCheckDigitsValidator _validator = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "114020040000300201355387";
    }

    [Benchmark]
    public void Validate()
    {
        Assert.True(_validator.Validate(_input));
    }
}
