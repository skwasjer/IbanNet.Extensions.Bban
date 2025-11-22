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
| Validate | .NET 8.0           | .NET 8.0           |  81.27 ns | 0.846 ns | 0.791 ns |  1.00 |    0.01 | 0.0139 |      88 B |        1.00 |
| Validate | .NET 10.0          | .NET 10.0          |  81.29 ns | 1.042 ns | 0.975 ns |  1.00 |    0.02 | 0.0139 |      88 B |        1.00 |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 145.88 ns | 2.592 ns | 2.425 ns |  1.79 |    0.04 | 0.0138 |      88 B |        1.00 |
