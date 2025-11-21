```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3


```
| Method | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| CleRib | .NET Framework 4.8 | .NET Framework 4.8 | 30.89 ns | 0.629 ns | 0.673 ns |  0.98 |    0.03 |         - |          NA |
| CleRib | .NET 8.0           | .NET 8.0           | 31.69 ns | 0.669 ns | 0.657 ns |  1.00 |    0.03 |         - |          NA |
