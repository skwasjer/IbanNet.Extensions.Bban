using BenchmarkDotNet.Attributes;
using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark;

[MemoryDiagnoser]
public class Mod9710Benchmark : AlgorithmBenchmark
{
    private readonly Mod9710Algorithm _mod9710 = new(Complement.Remainder);

    private string _input = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "BA3912900e9401Z28494";
    }

    [Benchmark]
    public void Mod9710()
    {
        _mod9710.Compute(_input);
    }
}
