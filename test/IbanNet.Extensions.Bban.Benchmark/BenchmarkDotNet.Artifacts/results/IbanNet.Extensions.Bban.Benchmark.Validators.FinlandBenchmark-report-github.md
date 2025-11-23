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
| Validate | .NET 10.0          | .NET 10.0          | 22.51 ns | 0.136 ns | 0.120 ns |  1.00 |    0.01 |      - |         - |          NA |
| Validate | .NET 8.0           | .NET 8.0           | 23.64 ns | 0.226 ns | 0.201 ns |  1.05 |    0.01 |      - |         - |          NA |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 87.01 ns | 0.643 ns | 0.570 ns |  3.87 |    0.03 | 0.0139 |      88 B |          NA |
