using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark;

[MemoryDiagnoser]
public class Mod11Benchmark : AlgorithmBenchmark
{
    private readonly Mod11CheckDigitsCalculator _mod11 = new();

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
