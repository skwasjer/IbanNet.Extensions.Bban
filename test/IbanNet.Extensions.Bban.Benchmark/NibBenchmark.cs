using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark;

[MemoryDiagnoser]
public class NibBenchmark : AlgorithmBenchmark
{
    private readonly NibAlgorithm _nib = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "0002012312345678901";
    }

    [Benchmark]
    public void Nib()
    {
        _nib.Compute(_input);
    }
}
