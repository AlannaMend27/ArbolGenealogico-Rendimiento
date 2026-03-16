using System;
using BenchmarkDotNet.Attributes;
using Arbol_Core.DataStructures;
using Arbol_Core.Models;

[MemoryDiagnoser] // mide memoria
public class GrafoBenchmark
{
    private Grafo grafo;

    [Params(10, 20, 30)] // tamaño del test
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        grafo = new Grafo();

        for (int i = 0; i < N; i++)
        {
            var p = new Persona(
                "Nombre",
                "Apellido",
                i.ToString(),
                DateTime.Now,
                20,
                10 + i * 0.01,
                -84 + i * 0.01,
                "",
                "familiar"
            );

            grafo.AgregarNodo(p);
        }
    }

    [Benchmark]
    public void ConstruirAristas()
    {
        grafo.ConstruirAristas();
    }

    [Benchmark]
    public double DistanciaPromedio()
    {
        return grafo.CalcularDistanciaPromedio();
    }

    [Benchmark]
    public void ParMasLejano()
    {
        grafo.ObtenerParMasLejano();
    }

    [Benchmark]
    public void ParMasCercano()
    {
        grafo.ObtenerParMasCercano();
    }
}