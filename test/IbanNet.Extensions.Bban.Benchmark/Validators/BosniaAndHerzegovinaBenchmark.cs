using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MemoryDiagnoser]
public class BosniaAndHerzegovinaBenchmark : ValidatorBenchmark
{
    private readonly BosniaAndHerzegovinaMod97NationalCheckDigitsValidator _validator = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "1290079401028494";
    }

    [Benchmark]
    public void Validate()
    {
        Assert.True(_validator.Validate(_input));
    }
}
