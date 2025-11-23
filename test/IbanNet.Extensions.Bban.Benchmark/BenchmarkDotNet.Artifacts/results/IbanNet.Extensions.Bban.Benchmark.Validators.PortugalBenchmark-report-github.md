```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method   | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Validate | .NET 10.0          | .NET 10.0          | 32.17 ns | 0.424 ns | 0.376 ns |  1.00 |    0.02 |      - |         - |          NA |
| Validate | .NET 8.0           | .NET 8.0           | 34.49 ns | 0.478 ns | 0.447 ns |  1.07 |    0.02 |      - |         - |          NA |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 91.98 ns | 0.893 ns | 0.835 ns |  2.86 |    0.04 | 0.0153 |      96 B |          NA |
