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
| Luhn   | .NET 10.0          | .NET 10.0          | 15.75 ns | 0.334 ns | 0.312 ns |  1.00 |    0.03 |         - |          NA |
| Luhn   | .NET 8.0           | .NET 8.0           | 15.90 ns | 0.102 ns | 0.080 ns |  1.01 |    0.02 |         - |          NA |
| Luhn   | .NET Framework 4.8 | .NET Framework 4.8 | 18.05 ns | 0.080 ns | 0.063 ns |  1.15 |    0.02 |         - |          NA |
