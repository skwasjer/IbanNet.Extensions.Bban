using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Algorithms;

[MemoryDiagnoser]
public class NorwayWeightedMod11Benchmark : AlgorithmBenchmark
{
    private readonly Norway.WeightedMod11Algorithm _mod11 = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "86011117947";
    }

    [Benchmark]
    public void Mod11()
    {
        _mod11.Compute(_input);
    }
}
