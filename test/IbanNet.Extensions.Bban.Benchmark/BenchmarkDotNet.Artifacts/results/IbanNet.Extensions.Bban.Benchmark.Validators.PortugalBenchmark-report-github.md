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
| Validate | .NET 10.0          | .NET 10.0          | 37.92 ns | 0.791 ns | 1.299 ns |  1.00 |    0.05 | 0.0153 |      96 B |        1.00 |
| Validate | .NET 8.0           | .NET 8.0           | 41.29 ns | 0.657 ns | 0.615 ns |  1.09 |    0.04 | 0.0153 |      96 B |        1.00 |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 92.07 ns | 0.699 ns | 0.654 ns |  2.43 |    0.08 | 0.0153 |      96 B |        1.00 |
