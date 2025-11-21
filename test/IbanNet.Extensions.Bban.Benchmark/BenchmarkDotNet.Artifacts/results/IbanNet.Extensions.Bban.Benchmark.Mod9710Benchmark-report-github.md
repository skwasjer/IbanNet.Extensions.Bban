```

BenchmarkDotNet v0.15.7, Windows 10 (10.0.19045.6575/22H2/2022Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]             : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET 8.0           : .NET 8.0.22 (8.0.22, 8.0.2225.52707), X64 RyuJIT x86-64-v3
  .NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9310.0), X64 RyuJIT VectorSize=256


```
| Method                                 | Job                | Runtime            | Mean     | Error    | StdDev   | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------- |------------------- |------------------- |---------:|---------:|---------:|------:|--------:|----------:|------------:|
| &#39;ISO 7064 MOD 97-10&#39;                   | .NET 8.0           | .NET 8.0           | 37.35 ns | 0.774 ns | 0.860 ns |  0.97 |    0.03 |         - |          NA |
| &#39;ISO 7064 MOD 97-10 (IbanNet library)&#39; | .NET 8.0           | .NET 8.0           | 38.45 ns | 0.541 ns | 0.507 ns |  1.00 |    0.02 |         - |          NA |
| &#39;ISO 7064 MOD 97-10&#39;                   | .NET Framework 4.8 | .NET Framework 4.8 | 56.31 ns | 1.110 ns | 1.234 ns |  1.46 |    0.04 |         - |          NA |
| &#39;ISO 7064 MOD 97-10 (IbanNet library)&#39; | .NET Framework 4.8 | .NET Framework 4.8 | 68.07 ns | 0.700 ns | 0.655 ns |  1.77 |    0.03 |         - |          NA |
