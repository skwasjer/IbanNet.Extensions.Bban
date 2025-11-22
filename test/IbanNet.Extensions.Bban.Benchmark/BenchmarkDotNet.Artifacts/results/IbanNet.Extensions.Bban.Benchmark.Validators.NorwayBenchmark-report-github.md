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
| Validate | .NET 10.0          | .NET 10.0          |  39.78 ns | 0.821 ns | 1.394 ns |  1.00 |    0.05 | 0.0166 |     104 B |        1.00 |
| Validate | .NET 8.0           | .NET 8.0           |  40.63 ns | 0.838 ns | 1.201 ns |  1.02 |    0.05 | 0.0166 |     104 B |        1.00 |
| Validate | .NET Framework 4.8 | .NET Framework 4.8 | 100.38 ns | 2.008 ns | 2.062 ns |  2.53 |    0.10 | 0.0178 |     112 B |        1.08 |
