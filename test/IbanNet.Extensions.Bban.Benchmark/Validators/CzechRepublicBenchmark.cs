using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MemoryDiagnoser]
public class CzechRepublicBenchmark : ValidatorBenchmark
{
    private readonly CzechRepublic.Prefix _prefixValidator = new();
    private readonly CzechRepublic.Account _accountValidator = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "01231234571234567899";
    }

    [Benchmark]
    public void Validate()
    {
        // We have to validate both parts to fully validate a Czech BBAN.
        Assert.True(_prefixValidator.Validate(_input) && _accountValidator.Validate(_input));
    }
}
