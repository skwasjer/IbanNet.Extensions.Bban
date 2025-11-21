```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| Nib    | .NET 8.0           | .NET 8.0           | 19.66 ns | 0.369 ns | 0.362 ns |  1.00 |    0.02 |         - |          NA |
| Nib    | .NET Framework 4.8 | .NET Framework 4.8 | 22.66 ns | 0.184 ns | 0.154 ns |  1.15 |    0.02 |         - |          NA |
