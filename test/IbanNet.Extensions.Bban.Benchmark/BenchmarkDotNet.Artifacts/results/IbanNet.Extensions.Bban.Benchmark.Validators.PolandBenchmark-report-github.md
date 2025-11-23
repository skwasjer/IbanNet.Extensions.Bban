```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method   | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | Gen0   | Allocated | Alloc Ratio |
|--------- |------------------- |------------------- |---------:|---------:|---------:|------:|-------:|----------:|------------:|
| Validate | .NET 10.0          | .NET 10.0          | 25.88 ns | 0.071 ns | 0.066 ns |  1.00 | 0.0102 |      64 B |        1.00 |
| Validate | .NET 8.0           | .NET 8.0           | 28.11 ns | 0.185 ns | 0.173 ns |  1.09 | 0.0102 |      64 B |        1.00 |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 70.93 ns | 0.249 ns | 0.233 ns |  2.74 | 0.0114 |      72 B |        1.12 |
