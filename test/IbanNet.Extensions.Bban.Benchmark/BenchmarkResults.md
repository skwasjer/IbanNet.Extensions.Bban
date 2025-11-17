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
| 'ISO 7064 MOD 97-10'                   | .NET 8.0           | .NET 8.0           | 30.93 ns | 0.027 ns | 0.024 ns |  0.82 |    0.02 |         - |          NA |
| 'ISO 7064 MOD 97-10 (IbanNet library)' | .NET 8.0           | .NET 8.0           | 37.81 ns | 0.778 ns | 0.764 ns |  1.00 |    0.03 |         - |          NA |
| 'ISO 7064 MOD 97-10'                   | .NET Framework 4.8 | .NET Framework 4.8 | 58.27 ns | 0.118 ns | 0.105 ns |  1.54 |    0.03 |         - |          NA |
| 'ISO 7064 MOD 97-10 (IbanNet library)' | .NET Framework 4.8 | .NET Framework 4.8 | 65.18 ns | 0.060 ns | 0.056 ns |  1.72 |    0.03 |         - |          NA |

### CLI

To run the benchmark:
```
cd ./test/Benchmark
dotnet run -c Release -f net8.0 --runtimes net80 net48
```
