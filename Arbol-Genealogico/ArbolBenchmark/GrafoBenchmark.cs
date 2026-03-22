using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Arbol_Core.DataStructures;
using Arbol_Core.Models;

[MemoryDiagnoser]
[SimpleJob(
    launchCount: 1,
    warmupCount: 1,
    iterationCount: 3
)]
public class GrafoBenchmark
{
    private Grafo grafo = null!;
    private Arbol arbol = null!;
    private Persona persona1 = null!;
    private Persona persona2 = null!;

    [Params(5, 10, 15)] // pequeño para que no use mucha RAM
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        grafo = new Grafo();
        arbol = new Arbol();

        for (int i = 0; i < N; i++)
        {
            var p = new Persona(
                "Nombre",
                "Apellido",
                i.ToString(),
                DateTime.Now.AddYears(-20),
                20,
                10 + i,
                -84 + i,
                "",
                "familiar"
            );

            grafo.AgregarNodo(p);
            arbol.AgregarPersona(p);

            if (i == 0) persona1 = p;
            if (i == 1) persona2 = p;
        }
    }

    // ✅ VALIDACION
    [Benchmark]
    public List<string> ObtenerErroresValidacion()
    {
        return persona1.ObtenerErroresValidacion();
    }

    // ✅ AGREGAR PERSONA
    [Benchmark]
    public bool AgregarPersona()
    {
        var p = new Persona(
            "Nuevo",
            "Apellido",
            Guid.NewGuid().ToString(),
            DateTime.Now.AddYears(-30),
            30,
            10,
            -84,
            "",
            "familiar"
        );

        return arbol.AgregarPersona(p);
    }

    // ✅ GRAFO
    [Benchmark]
    public void ConstruirAristas()
    {
        grafo.ConstruirAristas();
    }

    // ✅ PAR MAS LEJANO
    [Benchmark]
    public void ObtenerParMasLejano()
    {
        grafo.ObtenerParMasLejano();
    }

    // ✅ PAR MAS CERCANO
    [Benchmark]
    public void ObtenerParMasCercano()
    {
        grafo.ObtenerParMasCercano();
    }
}