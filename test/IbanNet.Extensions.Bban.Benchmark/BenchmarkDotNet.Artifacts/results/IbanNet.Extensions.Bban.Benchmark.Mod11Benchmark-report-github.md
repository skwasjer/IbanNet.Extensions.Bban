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
| Mod11  | .NET 10.0          | .NET 10.0          | 15.66 ns | 0.024 ns | 0.020 ns |  1.00 |         - |          NA |
| Mod11  | .NET 8.0           | .NET 8.0           | 17.20 ns | 0.025 ns | 0.024 ns |  1.10 |         - |          NA |
| Mod11  | .NET Framework 4.8 | .NET Framework 4.8 | 18.82 ns | 0.015 ns | 0.013 ns |  1.20 |         - |          NA |
