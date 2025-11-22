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
| Nib    | .NET 10.0          | .NET 10.0          | 19.39 ns | 0.224 ns | 0.187 ns |  1.00 |         - |          NA |
| Nib    | .NET 8.0           | .NET 8.0           | 20.94 ns | 0.106 ns | 0.099 ns |  1.08 |         - |          NA |
| Nib    | .NET Framework 4.8 | .NET Framework 4.8 | 21.77 ns | 0.159 ns | 0.141 ns |  1.12 |         - |          NA |
