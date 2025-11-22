```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | Allocated | Alloc Ratio |
|------- |------------------- |------------------- |---------:|---------:|---------:|------:|----------:|------------:|
| Luhn   | .NET 10.0          | .NET 10.0          | 15.47 ns | 0.089 ns | 0.074 ns |  1.00 |         - |          NA |
| Luhn   | .NET 8.0           | .NET 8.0           | 16.57 ns | 0.249 ns | 0.208 ns |  1.07 |         - |          NA |
| Luhn   | .NET Framework 4.8 | .NET Framework 4.8 | 17.93 ns | 0.077 ns | 0.065 ns |  1.16 |         - |          NA |
