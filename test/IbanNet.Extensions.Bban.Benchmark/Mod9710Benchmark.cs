using BenchmarkDotNet.Attributes;
using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark;

[MemoryDiagnoser]
public class Mod9710Benchmark : AlgorithmBenchmark
{
    private readonly Mod97CheckDigitsCalculator _mod9710Calculator = new();
    private readonly Mod9710Algorithm _mod9710 = new(Complement.Remainder);

    private string _input = null!;
    private char[] _inputArr = null!;

    [GlobalSetup]
    public void Setup()
    {
        _input = "BA3912900e9401Z28494";
        _inputArr = _input.ToCharArray();
    }

    [Benchmark(Description = "ISO 7064 MOD 97-10")]
    public void Mod9710()
    {
        _mod9710.Compute(_input);
    }

    [Benchmark(Description = "ISO 7064 MOD 97-10 (IbanNet library)", Baseline = true)]
    public void CoreMod9710()
    {
        _mod9710Calculator.Compute(_inputArr);
    }
}
