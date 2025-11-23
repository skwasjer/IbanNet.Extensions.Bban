# CLI

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

## Benchmarks


### Check digit algorithms

```
dotnet run -c Release -f net10.0 --runtimes net10.0 net80 net48 --algorithms
```

#### General

- [Cin](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Algorithms.CinBenchmark-report-github)
- [Clé Rib](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Algorithms.CleRibBenchmark-report-github)
- [Luhn](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Algorithms.LuhnBenchmark-report-github)
- [Mod-97,10](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Algorithms.Mod9710Benchmark-report-github)
- [Nib](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Algorithms.NibBenchmark-report-github)

#### Country specific/unnamed

- [Weighted Mod-10 (Poland)](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Algorithms.PolandWeightedMod10Benchmark-report-github)
- [Weighted Mod-11 (Czech Republic)](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Algorithms.CzechRepublicWeightedMod11Benchmark-report-github)
- [Weighted Mod-11 (Norway)](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Algorithms.NorwayWeightedMod11Benchmark-report-github)


### Validators (by country)

```
dotnet run -c Release -f net10.0 --runtimes net10.0 net80 net48 --validators
```

- [Belgium](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.BelgiumBenchmark-report-github)
- [Bosnia and Herzegovina](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.BosniaAndHerzegovinaBenchmark-report-github)
- [Czech Republic](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.CzechRepublicBenchmark-report-github)
- [Finland](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.FinlandBenchmark-report-github)
- [France, Monaco and Mauritania](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.FranceMonacoAndMauritaniaBenchmarkBenchmark-report-github)
- [Italy and San Marino](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.ItalyAndSanMarinoBenchmark-report-github)
- [Norway](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.NorwayBenchmark-report-github)
- [Poland](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.PolandBenchmark-report-github)
- [Portugal](BenchmarkDotNet.Artifacts/results/IbanNet.Extensions.Bban.Benchmark.Validators.PortugalBenchmark-report-github)
