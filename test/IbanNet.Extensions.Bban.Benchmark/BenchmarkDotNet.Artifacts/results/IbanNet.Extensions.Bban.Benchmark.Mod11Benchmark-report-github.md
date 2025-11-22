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
| Mod11  | .NET 10.0          | .NET 10.0          | 16.41 ns | 0.250 ns | 0.234 ns |  1.00 |    0.02 |         - |          NA |
| Mod11  | .NET 8.0           | .NET 8.0           | 18.27 ns | 0.357 ns | 0.334 ns |  1.11 |    0.02 |         - |          NA |
| Mod11  | .NET Framework 4.8 | .NET Framework 4.8 | 19.52 ns | 0.069 ns | 0.058 ns |  1.19 |    0.02 |         - |          NA |
