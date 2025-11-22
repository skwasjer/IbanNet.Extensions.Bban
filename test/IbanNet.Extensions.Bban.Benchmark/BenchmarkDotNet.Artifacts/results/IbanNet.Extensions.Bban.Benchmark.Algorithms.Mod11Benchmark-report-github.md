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
| Mod11  | .NET 10.0          | .NET 10.0          | 14.98 ns | 0.066 ns | 0.055 ns |  1.00 |    0.01 |         - |          NA |
| Mod11  | .NET 8.0           | .NET 8.0           | 17.70 ns | 0.297 ns | 0.278 ns |  1.18 |    0.02 |         - |          NA |
| Mod11  | .NET Framework 4.8 | .NET Framework 4.8 | 18.60 ns | 0.073 ns | 0.061 ns |  1.24 |    0.01 |         - |          NA |
