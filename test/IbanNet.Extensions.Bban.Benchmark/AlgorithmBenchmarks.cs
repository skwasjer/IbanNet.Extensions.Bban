using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;
using IbanNet.CheckDigits.Calculators;
using IbanNet.Extensions.Bban.CheckDigits;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark;

[MarkdownExporterAttribute.GitHub]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Alphabetical)]
[MemoryDiagnoser]
[InliningDiagnoser(false, ["IbanNet.Extensions.Bban"])]
public class AlgorithmBenchmarks
{
    private readonly Mod97CheckDigitsCalculator _mod9710Calculator = new();
    private readonly Mod9710Algorithm _mod9710 = new(Complement.Remainder);
    private char[] _alphaNumericData = null!;

    [GlobalSetup]
    public void Setup()
    {
        // Note: for fair comparisons, the same data (and length) is used for all numeric (digits only) and alphanumeric (mixed) algorithms respectively.
        _alphaNumericData = "BA3912900e9401Z28494".ToCharArray();
    }

    [Benchmark(Description = "ISO 7064 MOD 97-10")]
    public void Mod9710()
    {
        _mod9710.Compute(_alphaNumericData);
    }

    [Benchmark(Description = "ISO 7064 MOD 97-10 (IbanNet library)", Baseline = true)]
    public void CoreMod9710()
    {
        _mod9710Calculator.Compute(_alphaNumericData);
    }
}
