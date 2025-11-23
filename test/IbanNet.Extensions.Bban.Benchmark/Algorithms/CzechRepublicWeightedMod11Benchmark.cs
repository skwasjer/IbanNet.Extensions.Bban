using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Algorithms;

[MemoryDiagnoser]
public class CzechRepublicWeightedMod11Benchmark : AlgorithmBenchmark
{
    // Specifically, we use the account weights, as this is the longest array.
    private readonly CzechRepublic.WeightedMod11Algorithm _mod11 = new([6, 3, 7, 9, 10, 5, 8, 4, 2, 1]);

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "1234567890";
    }

    [Benchmark]
    public void Mod11()
    {
        _mod11.Compute(_input);
    }
}
