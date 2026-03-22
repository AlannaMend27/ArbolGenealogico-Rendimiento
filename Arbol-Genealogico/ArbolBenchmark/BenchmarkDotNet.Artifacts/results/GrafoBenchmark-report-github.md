```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.8037/24H2/2024Update/HudsonValley)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.101
  [Host]     : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3
  Job-FGEKWY : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v3

IterationCount=3  LaunchCount=1  WarmupCount=1  

```
| Method                   | N  | Mean         | Error          | StdDev      | Gen0   | Gen1   | Allocated |
|------------------------- |--- |-------------:|---------------:|------------:|-------:|-------:|----------:|
| **ObtenerErroresValidacion** | **5**  |    **44.143 ns** |      **2.7712 ns** |   **0.1519 ns** | **0.0076** |      **-** |      **32 B** |
| AgregarPersona           | 5  |   723.448 ns |  1,785.2269 ns |  97.8543 ns | 0.0429 | 0.0210 |     272 B |
| ConstruirAristas         | 5  |   831.608 ns |    174.0192 ns |   9.5386 ns | 0.1888 |      - |     792 B |
| ObtenerParMasLejano      | 5  |   241.455 ns |     15.0845 ns |   0.8268 ns | 0.0362 |      - |     152 B |
| ObtenerParMasCercano     | 5  |   238.523 ns |      6.0065 ns |   0.3292 ns | 0.0362 |      - |     152 B |
| CalcularDistancia        | 5  |    18.914 ns |      0.7457 ns |   0.0409 ns |      - |      - |         - |
| BuscarPorCedula          | 5  |     7.212 ns |      0.6326 ns |   0.0347 ns |      - |      - |         - |
| **ObtenerErroresValidacion** | **10** |    **45.618 ns** |      **2.1233 ns** |   **0.1164 ns** | **0.0076** |      **-** |      **32 B** |
| AgregarPersona           | 10 |   742.681 ns |  2,064.6615 ns | 113.1711 ns | 0.0429 | 0.0210 |     272 B |
| ConstruirAristas         | 10 | 2,811.670 ns |    188.2155 ns |  10.3167 ns | 0.7324 |      - |    3072 B |
| ObtenerParMasLejano      | 10 |   554.338 ns |     22.2858 ns |   1.2216 ns | 0.0458 |      - |     192 B |
| ObtenerParMasCercano     | 10 |   544.515 ns |     33.5761 ns |   1.8404 ns | 0.0458 |      - |     192 B |
| CalcularDistancia        | 10 |    18.874 ns |      0.4018 ns |   0.0220 ns |      - |      - |         - |
| BuscarPorCedula          | 10 |     7.278 ns |      4.8221 ns |   0.2643 ns |      - |      - |         - |
| **ObtenerErroresValidacion** | **15** |    **44.400 ns** |     **10.3649 ns** |   **0.5681 ns** | **0.0076** |      **-** |      **32 B** |
| AgregarPersona           | 15 |   788.293 ns |  1,514.4180 ns |  83.0104 ns | 0.0429 | 0.0210 |     272 B |
| ConstruirAristas         | 15 | 7,719.821 ns | 12,778.7820 ns | 700.4482 ns | 1.6556 |      - |    6952 B |
| ObtenerParMasLejano      | 15 | 1,260.465 ns |    142.8616 ns |   7.8307 ns | 0.0553 |      - |     232 B |
| ObtenerParMasCercano     | 15 | 1,259.731 ns |    233.8976 ns |  12.8207 ns | 0.0553 |      - |     232 B |
| CalcularDistancia        | 15 |    18.892 ns |      1.5193 ns |   0.0833 ns |      - |      - |         - |
| BuscarPorCedula          | 15 |     5.124 ns |      0.3018 ns |   0.0165 ns |      - |      - |         - |
