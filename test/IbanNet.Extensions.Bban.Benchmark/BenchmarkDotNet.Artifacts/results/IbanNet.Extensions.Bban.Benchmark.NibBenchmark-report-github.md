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
| Nib    | .NET 10.0          | .NET 10.0          | 20.25 ns | 0.138 ns | 0.122 ns |  1.00 |         - |          NA |
| Nib    | .NET 8.0           | .NET 8.0           | 21.27 ns | 0.220 ns | 0.184 ns |  1.05 |         - |          NA |
| Nib    | .NET Framework 4.8 | .NET Framework 4.8 | 23.71 ns | 0.202 ns | 0.169 ns |  1.17 |         - |          NA |
