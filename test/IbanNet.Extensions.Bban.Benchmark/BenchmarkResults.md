# IbanNet.Extensions.Bban benchmark results

## Algorithms

```
BenchmarkDotNet v0.15.6, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256
```

| Method                                 | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| 'ISO 7064 MOD 97-10'                   | .NET 8.0           | .NET 8.0           | 32.12 ns | 0.440 ns | 0.343 ns |  0.83 |    0.01 |         - |          NA |
| 'ISO 7064 MOD 97-10 (IbanNet library)' | .NET 8.0           | .NET 8.0           | 38.68 ns | 0.552 ns | 0.490 ns |  1.00 |    0.02 |         - |          NA |
| 'ISO 7064 MOD 97-10'                   | .NET Framework 4.8 | .NET Framework 4.8 | 48.98 ns | 0.169 ns | 0.141 ns |  1.27 |    0.02 |         - |          NA |
| 'ISO 7064 MOD 97-10 (IbanNet library)' | .NET Framework 4.8 | .NET Framework 4.8 | 66.83 ns | 0.572 ns | 0.535 ns |  1.73 |    0.03 |         - |          NA |

### CLI

To run the benchmark:
```
cd ./test/Benchmark
dotnet run -c Release -f net8.0 --runtimes net80 net48
```
