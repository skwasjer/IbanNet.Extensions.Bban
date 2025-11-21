using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark;

[MemoryDiagnoser]
public class LuhnBenchmark : AlgorithmBenchmark
{
    private readonly LuhnAlgorithm _luhn = new();

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "8739129009940";
    }

    [Benchmark]
    public void Luhn()
    {
        _luhn.Compute(_input);
    }
}
