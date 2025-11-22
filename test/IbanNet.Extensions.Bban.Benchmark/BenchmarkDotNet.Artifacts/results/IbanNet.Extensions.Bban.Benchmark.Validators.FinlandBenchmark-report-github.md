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
| Validate | .NET 10.0          | .NET 10.0          | 32.98 ns | 0.641 ns | 0.919 ns |  1.00 |    0.04 | 0.0114 |      72 B |        1.00 |
| Validate | .NET 8.0           | .NET 8.0           | 34.63 ns | 0.675 ns | 0.631 ns |  1.05 |    0.03 | 0.0114 |      72 B |        1.00 |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 83.78 ns | 0.389 ns | 0.304 ns |  2.54 |    0.07 | 0.0139 |      88 B |        1.22 |
