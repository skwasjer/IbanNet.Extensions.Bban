```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method   | Job                | Runtime            | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------- |------------------- |------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Validate | .NET 10.0          | .NET 10.0          |  83.61 ns | 1.458 ns | 1.218 ns |  1.00 |    0.02 | 0.0509 |     320 B |        1.00 |
| Validate | .NET 8.0           | .NET 8.0           | 102.59 ns | 2.052 ns | 4.238 ns |  1.23 |    0.05 | 0.0612 |     384 B |        1.20 |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 211.62 ns | 4.022 ns | 3.565 ns |  2.53 |    0.05 | 0.0663 |     417 B |        1.30 |
