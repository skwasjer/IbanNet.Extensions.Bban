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
| CleRib | .NET 10.0          | .NET 10.0          | 12.59 ns | 0.155 ns | 0.138 ns |  1.00 |    0.01 |         - |          NA |
| CleRib | .NET 8.0           | .NET 8.0           | 23.60 ns | 0.263 ns | 0.246 ns |  1.87 |    0.03 |         - |          NA |
| CleRib | .NET Framework 4.8 | .NET Framework 4.8 | 29.84 ns | 0.297 ns | 0.263 ns |  2.37 |    0.03 |         - |          NA |
