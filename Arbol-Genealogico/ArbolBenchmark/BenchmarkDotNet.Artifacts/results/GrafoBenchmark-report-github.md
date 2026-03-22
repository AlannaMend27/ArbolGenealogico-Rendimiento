```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.8037/24H2/2024Update/HudsonValley)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  Job-FGEKWY : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

IterationCount=3  LaunchCount=1  WarmupCount=1  

```
| Method                   | N  | Mean        | Error        | StdDev     | Gen0   | Gen1   | Allocated |
|------------------------- |--- |------------:|-------------:|-----------:|-------:|-------:|----------:|
| **ObtenerErroresValidacion** | **5**  |    **45.40 ns** |     **4.770 ns** |   **0.261 ns** | **0.0076** |      **-** |      **32 B** |
| AgregarPersona           | 5  |   753.85 ns | 2,223.330 ns | 121.868 ns | 0.0429 | 0.0210 |     272 B |
| ConstruirAristas         | 5  |   823.54 ns |   261.190 ns |  14.317 ns | 0.1888 |      - |     792 B |
| ObtenerParMasLejano      | 5  |   236.86 ns |    23.462 ns |   1.286 ns | 0.0362 |      - |     152 B |
| ObtenerParMasCercano     | 5  |   239.04 ns |    40.814 ns |   2.237 ns | 0.0362 |      - |     152 B |
| **ObtenerErroresValidacion** | **10** |    **46.93 ns** |     **9.180 ns** |   **0.503 ns** | **0.0076** |      **-** |      **32 B** |
| AgregarPersona           | 10 |   731.90 ns | 1,747.863 ns |  95.806 ns | 0.0429 | 0.0210 |     272 B |
| ConstruirAristas         | 10 | 2,796.36 ns |   259.751 ns |  14.238 ns | 0.7324 |      - |    3072 B |
| ObtenerParMasLejano      | 10 |   548.77 ns |   267.539 ns |  14.665 ns | 0.0458 |      - |     192 B |
| ObtenerParMasCercano     | 10 |   542.53 ns |    55.838 ns |   3.061 ns | 0.0458 |      - |     192 B |
| **ObtenerErroresValidacion** | **15** |    **43.93 ns** |     **0.847 ns** |   **0.046 ns** | **0.0076** |      **-** |      **32 B** |
| AgregarPersona           | 15 |   731.53 ns | 1,755.197 ns |  96.208 ns | 0.0429 | 0.0210 |     272 B |
| ConstruirAristas         | 15 | 6,620.72 ns | 1,969.489 ns | 107.954 ns | 1.6556 |      - |    6952 B |
| ObtenerParMasLejano      | 15 | 1,277.32 ns |   456.342 ns |  25.014 ns | 0.0553 |      - |     232 B |
| ObtenerParMasCercano     | 15 | 1,236.53 ns |    65.430 ns |   3.586 ns | 0.0553 |      - |     232 B |
