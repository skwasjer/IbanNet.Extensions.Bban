```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method   | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Validate | .NET 10.0          | .NET 10.0          | 22.01 ns | 0.155 ns | 0.145 ns |  1.00 |    0.01 |      - |         - |          NA |
| Validate | .NET 8.0           | .NET 8.0           | 23.09 ns | 0.190 ns | 0.178 ns |  1.05 |    0.01 |      - |         - |          NA |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 75.25 ns | 0.593 ns | 0.555 ns |  3.42 |    0.03 | 0.0114 |      72 B |          NA |
