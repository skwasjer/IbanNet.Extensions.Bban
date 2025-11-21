using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Order;

namespace IbanNet.Extensions.Bban.Benchmark;

[MarkdownExporterAttribute.GitHub]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Alphabetical)]
[InliningDiagnoser(false, ["IbanNet.Extensions.Bban"])]
public abstract class AlgorithmBenchmark
{
}
