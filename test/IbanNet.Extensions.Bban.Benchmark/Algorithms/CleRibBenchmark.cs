using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark.Algorithms;

[MemoryDiagnoser]
public class CleRibBenchmark : AlgorithmBenchmark
{
    private readonly CleRibAlgorithm _cleRib = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "20041010050500013M026";
    }

    [Benchmark]
    public void CleRib()
    {
        _cleRib.Compute(_input);
    }
}
