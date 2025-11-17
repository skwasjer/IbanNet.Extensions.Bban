using BenchmarkDotNet.Running;

namespace IbanNet.Extensions.Bban.Benchmark;

public static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<AlgorithmBenchmarks>();
    }
}
