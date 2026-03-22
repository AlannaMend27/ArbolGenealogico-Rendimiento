using System;
using System.Diagnostics;
using Arbol_Core.DataStructures;
using Arbol_Core.Models;

public class StressTest
{
    public static void Run()
    {
        int N = 200; // tamaño grande

        var grafo = new Grafo();
        var arbol = new Arbol();

        Persona p1 = null;
        Persona p2 = null;

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

            if (i == 0) p1 = p;
            if (i == 1) p2 = p;
        }

        var proceso = Process.GetCurrentProcess();

        var cpuAntes = proceso.TotalProcessorTime;
        long memAntes = GC.GetTotalMemory(true);

        var sw = Stopwatch.StartNew();

        // ===== STRESS =====

        for (int i = 0; i < 1000; i++)
        {
            p1.ObtenerErroresValidacion();
            p1.CalcularDistancia(p2);
            arbol.BuscarPorCedula(p1.Cedula);

            var nueva = new Persona(
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

            arbol.AgregarPersona(nueva);
        }

        grafo.ConstruirAristas();
        grafo.ObtenerParMasLejano();
        grafo.ObtenerParMasCercano();

        sw.Stop();

        var cpuDespues = proceso.TotalProcessorTime;
        long memDespues = GC.GetTotalMemory(true);

        double cpuUsado = (cpuDespues - cpuAntes).TotalMilliseconds;
        long memoriaUsada = memDespues - memAntes;

        Console.WriteLine("===== STRESS TEST =====");
        Console.WriteLine("Tiempo ms: " + sw.ElapsedMilliseconds);
        Console.WriteLine("CPU ms: " + cpuUsado);
        Console.WriteLine("Memoria bytes: " + memoriaUsada);
    }
}

/*DOTNET BENCHMARK
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

    [Params(5, 10, 15)]
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

    // ✅ DISTANCIA
    [Benchmark]
    public double CalcularDistancia()
    {
        return persona1.CalcularDistancia(persona2);
    }

    // ✅ BUSCAR POR CEDULA
    [Benchmark]
    public Persona BuscarPorCedula()
    {
        return arbol.BuscarPorCedula(persona1.Cedula);
    }
}*/