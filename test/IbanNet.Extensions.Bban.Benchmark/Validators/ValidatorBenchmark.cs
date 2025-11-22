using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;
using IbanNet.Extensions.Bban.Benchmark.Algorithms;
using IbanNet.Extensions.Bban.CheckDigits.Algorithms;

namespace IbanNet.Extensions.Bban.Benchmark.Validators;

[MarkdownExporterAttribute.GitHub]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Alphabetical)]
[InliningDiagnoser(false, ["IbanNet.Extensions.Bban"])]
public abstract class ValidatorBenchmark
{
}
