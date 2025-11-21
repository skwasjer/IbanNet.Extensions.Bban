using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark;

[MemoryDiagnoser]
public class CinBenchmark : AlgorithmBenchmark
{
    private readonly CinAlgorithm _cin = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "X0542811101000000123456";
    }

    [Benchmark]
    public void Cin()
    {
        _cin.Compute(_input);
    }
}
