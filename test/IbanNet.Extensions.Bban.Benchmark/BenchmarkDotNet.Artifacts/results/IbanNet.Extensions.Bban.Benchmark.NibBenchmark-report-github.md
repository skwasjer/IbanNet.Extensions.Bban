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
| Nib    | .NET 10.0          | .NET 10.0          | 19.15 ns | 0.069 ns | 0.057 ns |  1.00 |         - |          NA |
| Nib    | .NET 8.0           | .NET 8.0           | 20.22 ns | 0.062 ns | 0.055 ns |  1.06 |         - |          NA |
| Nib    | .NET Framework 4.8 | .NET Framework 4.8 | 22.37 ns | 0.044 ns | 0.039 ns |  1.17 |         - |          NA |
