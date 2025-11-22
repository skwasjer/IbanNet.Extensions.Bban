```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| Cin    | .NET 10.0          | .NET 10.0          | 22.42 ns | 0.473 ns | 0.464 ns |  1.00 |    0.03 |         - |          NA |
| Cin    | .NET 8.0           | .NET 8.0           | 24.24 ns | 0.154 ns | 0.136 ns |  1.08 |    0.02 |         - |          NA |
| Cin    | .NET Framework 4.8 | .NET Framework 4.8 | 29.42 ns | 0.342 ns | 0.320 ns |  1.31 |    0.03 |         - |          NA |
