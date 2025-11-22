## CLI

All benchmarks can be run from this path:

```
cd ./test/IbanNet.Extensions.Bban.Benchmark
```

To run the benchmark(s) with selector:

```
dotnet run -c Release -f net10.0 --runtimes net10.0 net80 net48
```

To run all the benchmark(s):

```
dotnet run -c Release -f net10.0 --runtimes net10.0 net80 net48 --all
```

### Benchmarks

#### Algorithms

```
dotnet run -c Release -f net10.0 --runtimes net10.0 net80 net48 --algorithms
```

- [Cin](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Artifacts.CinBenchmark-report-github)
- [Clé Rib](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Artifacts.CleRibBenchmark-report-github)
- [Luhn](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Artifacts.LuhnBenchmark-report-github)
- [Mod-11](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Artifacts.Mod11Benchmark-report-github)
- [Mod-97,10](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Artifacts.Mod9710Benchmark-report-github)
- [Nib](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Artifacts.NibBenchmark-report-github)


#### Validators (by country)

```
dotnet run -c Release -f net10.0 --runtimes net10.0 net80 net48 --validators
```

- [Belgium](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.BelgiumBenchmark-report-github)
- [Bosnia & Herzegovina](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.BosniaAndHerzegovinaBenchmark-report-github)
- [Finland](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.FinlandBenchmark-report-github)
- [France](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.FranceBenchmark-report-github)
- [Italy](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.ItalyBenchmark-report-github)
- [Norway](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.NorwayBenchmark-report-github)
- [Poland](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.PolandBenchmark-report-github)
- [Portugal](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.PortugalBenchmark-report-github)
