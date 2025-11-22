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
| Validate | .NET 10.0          | .NET 10.0          | 29.94 ns | 0.170 ns | 0.159 ns |  1.00 |    0.01 | 0.0114 |      72 B |        1.00 |
| Validate | .NET 8.0           | .NET 8.0           | 33.63 ns | 0.692 ns | 0.647 ns |  1.12 |    0.02 | 0.0114 |      72 B |        1.00 |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 80.10 ns | 0.172 ns | 0.152 ns |  2.68 |    0.01 | 0.0126 |      80 B |        1.11 |
