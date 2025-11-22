```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method  | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| Mod9710 | .NET 10.0          | .NET 10.0          | 31.47 ns | 0.226 ns | 0.188 ns |  1.00 |    0.01 |         - |          NA |
| Mod9710 | .NET 8.0           | .NET 8.0           | 36.52 ns | 0.546 ns | 0.511 ns |  1.16 |    0.02 |         - |          NA |
| Mod9710 | .NET Framework 4.8 | .NET Framework 4.8 | 52.42 ns | 0.261 ns | 0.244 ns |  1.67 |    0.01 |         - |          NA |
