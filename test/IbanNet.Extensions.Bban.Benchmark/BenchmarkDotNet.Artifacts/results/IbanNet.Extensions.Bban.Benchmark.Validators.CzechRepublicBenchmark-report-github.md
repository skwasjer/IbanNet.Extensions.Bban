```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method   | Job                | Runtime            | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------- |------------------- |------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Validate | .NET 8.0           | .NET 8.0           |  47.10 ns | 0.277 ns | 0.259 ns |  0.98 |    0.01 |      - |         - |          NA |
| Validate | .NET 10.0          | .NET 10.0          |  47.86 ns | 0.537 ns | 0.502 ns |  1.00 |    0.01 |      - |         - |          NA |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 150.87 ns | 1.197 ns | 1.061 ns |  3.15 |    0.04 | 0.0241 |     152 B |          NA |
