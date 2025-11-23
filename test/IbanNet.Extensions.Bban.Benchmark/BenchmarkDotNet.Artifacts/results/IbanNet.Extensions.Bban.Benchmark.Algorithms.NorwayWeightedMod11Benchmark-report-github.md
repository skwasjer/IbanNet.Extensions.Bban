```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 10.0          : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method | Job                | Runtime            | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|------- |------------------- |------------------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| Mod11  | .NET 10.0          | .NET 10.0          |  8.100 ns | 0.0229 ns | 0.0214 ns |  1.00 |    0.00 |         - |          NA |
| Mod11  | .NET 8.0           | .NET 8.0           | 12.173 ns | 0.0161 ns | 0.0142 ns |  1.50 |    0.00 |         - |          NA |
| Mod11  | .NET Framework 4.8 | .NET Framework 4.8 | 26.961 ns | 0.4641 ns | 0.4341 ns |  3.33 |    0.05 |         - |          NA |
