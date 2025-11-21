## CLI

To run the benchmark(s) with selector:

```
cd ./test/Benchmark
dotnet run -c Release -f net8.0 --runtimes net80 net48
```

To run all the benchmark(s):

```
cd ./test/Benchmark
dotnet run -c Release -f net8.0 --runtimes net80 net48 --all
```

### Benchmarks

- [Cin](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.CinBenchmark-report-github)
- [Clé Rib](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.CleRibBenchmark-report-github)
- [Luhn](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.LuhnBenchmark-report-github)
- [Mod-11](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Mod11Benchmark-report-github)
- [Mod-97,10](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Mod9710Benchmark-report-github)
- [Nib](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.NibBenchmark-report-github)
