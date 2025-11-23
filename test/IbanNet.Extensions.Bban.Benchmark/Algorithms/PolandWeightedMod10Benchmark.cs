using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.Validation.NationalCheckDigits;

namespace IbanNet.Extensions.Bban.Benchmark.Algorithms;

[MemoryDiagnoser]
public class PolandWeightedMod10Benchmark : AlgorithmBenchmark
{
    private readonly Poland.WeightedMod10Algorithm _mod10 = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "1020555";
    }

    [Benchmark]
    public void Mod10()
    {
        _mod10.Compute(_input);
    }
}
